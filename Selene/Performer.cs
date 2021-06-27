//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene
{
    using System;

    public static class Performer
    {
        public enum ExceptionAction
        {
            THROW_ERROR,
            CONTINUE
        }

        public static bool Do(Action action, ExceptionAction exceptionAction = ExceptionAction.CONTINUE)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (Exception e)
            {
                if (Enum.Equals(exceptionAction, ExceptionAction.THROW_ERROR)) throw new Exception(e.Message, e);
                return false;
            }
        }

        public static T Do<T>(Func<T> action, ExceptionAction exceptionAction = ExceptionAction.CONTINUE)
        {
            try
            {
                var val = action.Invoke();
                return val;
            }
            catch (Exception e)
            {
                if (Enum.Equals(exceptionAction, ExceptionAction.THROW_ERROR)) throw new Exception(e.Message, e);
                return default(T);
            }
        }

        public static bool Do(Action<Record> recordedAction, Record record, ExceptionAction exceptionAction = ExceptionAction.CONTINUE)
        {
            try
            {
                recordedAction.Invoke(record);
                Recorder.PassRecord(record);
                return true;
            }
            catch (Exception e)
            {
                Recorder.FailRecord(record);
                if (Enum.Equals(exceptionAction, ExceptionAction.THROW_ERROR)) throw new Exception(e.Message, e);
                return false;
            }
        }

        public static T Do<T>(Func<Record, T> recordedAction, Record record, ExceptionAction exceptionAction = ExceptionAction.CONTINUE)
        {
            try
            {
                var val = recordedAction.Invoke(record);
                Recorder.PassRecord(record);
                return val;
            }
            catch (Exception e)
            {
                Recorder.FailRecord(record);
                if (Enum.Equals(exceptionAction, ExceptionAction.THROW_ERROR)) throw new Exception(e.Message, e);
                return default(T);
            }
        }
    }
}
