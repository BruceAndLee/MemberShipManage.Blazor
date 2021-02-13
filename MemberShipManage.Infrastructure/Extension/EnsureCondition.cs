using System;
using System.Collections.Generic;
using System.Text;

namespace MemberShipManage.Infrastructurer.Extension
{
    public class EnsureCondition
    {
        public static void RunIf(bool condition, Action action)
        {
            if (condition && action != null)
            {
                action();
            }
        }

        public static void RunIf(bool condition, Action matchAction, Action unMatchAction)
        {
            if (condition)
            {
                matchAction?.Invoke();
            }
            else
            {
                unMatchAction?.Invoke();
            }
        }

        public static T RunIf<T>(bool condition, Func<T> actionTrue, Func<T> actionFalse)
        {
            if (condition)
            {
                return actionTrue();
            }
            else
            {
                return actionFalse();
            }
        }

        public static void RunIf(bool condition, Action<object> action, object param)
        {
            if (condition && action != null)
            {
                action(param);
            }
        }

        public static void RunIf<T>(Predicate<T> predicate, Action<object> action, T t1, object param)
        {
            if (predicate(t1) && action != null)
            {
                action(param);
            }
        }
    }
}
