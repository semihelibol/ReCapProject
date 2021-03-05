using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;
        private LoggerServiceBase _loggerServiceBase;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(typeof(FileLogger));
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }
        
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                var performance=$"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}";
                Debug.WriteLine(performance);
                _loggerServiceBase.Info(performance);
            }
            _stopwatch.Reset();
        }
    }
}
