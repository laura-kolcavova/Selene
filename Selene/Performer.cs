//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene
{
    using System;

    public static class Performer
    {
        public static void Do(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch(Exception e)
            {
                Log.Fail(e.Message);
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
                result = default(TResult);
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
                record.Error = e.Message;
                Log.Fail(record);
                result = default(TResult);
            }

            return result;
        }
    }
}
