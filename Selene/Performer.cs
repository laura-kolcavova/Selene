//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene
{
    using System;

    public static class Performer
    {
        public static void Do(Action action, string logMessage)
        {
            try
            {
                action.Invoke();
                Log.Pass(logMessage);
            }
            catch(Exception e)
            {
                logMessage += $" : {e.Message}";
                Log.Fail(logMessage);
                throw new Exception(e.Message, e);
            }
        }

        public static void Do(Action<Record> recordedAction, Record record)
        {
            try
            {
                recordedAction.Invoke(record);
                Log.Pass(record);
            }
            catch (Exception e)
            {
                record.Error = e.Message;
                Log.Fail(record);
                throw new Exception(e.Message, e);
            }
        }

        public static TResult Try<TResult>(Func<TResult> action, out TResult result)
        {
            try
            {
                result = action.Invoke();
            }
            catch
            {
                result = default;
            }

            return result;
        }

        public static TResult Try<TResult>(Func<TResult> recordedAction, string logMessage, out TResult result)
        {
            try
            {
                result = recordedAction.Invoke();
                Log.Pass(logMessage);
            }
            catch (Exception e)
            {
                result = default;
                logMessage += $" : {e.Message}";
                Log.Fail(logMessage);
            }

            return result;
        }

        public static TResult Try<TResult>(Func<Record, TResult> recordedAction, Record record, out TResult result)
        {
            try
            {
                result = recordedAction.Invoke(record);
                Log.Pass(record);
            }
            catch (Exception e)
            {
                result = default;
                record.Error = e.Message;
                Log.Fail(record);
            }

            return result;
        }
    }
}
