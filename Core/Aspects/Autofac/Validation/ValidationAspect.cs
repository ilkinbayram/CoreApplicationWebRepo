using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Linq;

using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using Core.Utilities.Results;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        private Type _returnDataType;

        public ValidationAspect(Type validatorType, Type returnDataType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
            _returnDataType = returnDataType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            if (e is ValidationException validationException)
            {
                if (_returnDataType == typeof(bool))
                { 
                    invocation.ReturnValue = new ErrorDataResult<bool>(false, true, validationException.Errors.Select(s => s.ErrorMessage).ToList()); 
                }
                else if (_returnDataType == typeof(byte))
                {
                    invocation.ReturnValue = new ErrorDataResult<byte>(0, true, validationException.Errors.Select(s => s.ErrorMessage).ToList());
                }
                else if (_returnDataType == typeof(short))
                {
                    invocation.ReturnValue = new ErrorDataResult<short>(-1, true, validationException.Errors.Select(s => s.ErrorMessage).ToList());
                }
                else if (_returnDataType == typeof(int))
                {
                    invocation.ReturnValue = new ErrorDataResult<int>(-1, true, validationException.Errors.Select(s => s.ErrorMessage).ToList());
                }
                else if (_returnDataType == typeof(long))
                {
                    invocation.ReturnValue = new ErrorDataResult<long>(-1, true, validationException.Errors.Select(s => s.ErrorMessage).ToList());
                }
                else if (_returnDataType == typeof(decimal))
                {
                    invocation.ReturnValue = new ErrorDataResult<decimal>(-1, true, validationException.Errors.Select(s => s.ErrorMessage).ToList());
                }
                else
                {
                    invocation.ReturnValue = new ErrorDataResult<object>(null, true, validationException.Errors.Select(s => s.ErrorMessage).ToList());
                }
            }
            else
            {
                if (_returnDataType == typeof(bool))
                {
                    invocation.ReturnValue = new ErrorDataResult<bool>(false, true, e.Message);
                }
                else if (_returnDataType == typeof(byte))
                {
                    invocation.ReturnValue = new ErrorDataResult<byte>(0, true, e.Message);
                }
                else if (_returnDataType == typeof(short))
                {
                    invocation.ReturnValue = new ErrorDataResult<short>(-1, true, e.Message);
                }
                else if (_returnDataType == typeof(int))
                {
                    invocation.ReturnValue = new ErrorDataResult<int>(-1, true, e.Message);
                }
                else if (_returnDataType == typeof(long))
                {
                    invocation.ReturnValue = new ErrorDataResult<long>(-1, true, e.Message);
                }
                else if (_returnDataType == typeof(decimal))
                {
                    invocation.ReturnValue = new ErrorDataResult<decimal>(-1, true, e.Message);
                }
                else
                {
                    invocation.ReturnValue = new ErrorDataResult<object>(null, true, e.Message);
                }
            }
        }
    }
}
