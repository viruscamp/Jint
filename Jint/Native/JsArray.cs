using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native
{
    [Serializable]
    public sealed class JsArray : JsObject
    {
        protected internal int length = 0;
        
        public JsArray(JsObject prototype)
            : base(prototype)
        {
        }

        public override bool ToBoolean()
        {
            return Length > 0;
        }

        public override int Length
        {
            get
            {
                return length;
            }
            set
            {
                int oldLen = length;
                length = value;

                for (int i = length; i < oldLen; i++)
                    if (HasOwnProperty(i.ToString()))
                        Delete(i.ToString());
            }
        }

        public override JsInstance this[string index]
        {
            get
            {
                return base[index];
            }
            set
            {
                try
                {
                    int i = Convert.ToInt32(index);
                    if (i < 0)
                        throw new JintException("Index is out of range");
                    length = Math.Max(length, i + 1);
                }
                catch (FormatException)
                {
                }
                finally
                {
                    base[index] = value;
                }
            }
        }

        public override void DefineOwnProperty(string key, JsInstance value)
        {
            try
            {
                int i = Convert.ToInt32(key);
                if (i < 0)
                    throw new JintException("Index is out of range");
                length = Math.Max(length, i + 1);
            }
            catch (FormatException)
            {
            }
            finally
            {
                base.DefineOwnProperty(key, value);
            }
        }

        public override double ToNumber()
        {
            return Length;
        }

        public override bool Equals(object obj)
        {
            if (obj is JsArray)
            {
                return this.Value.Equals(((JsArray)obj).Value);
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            var list = new List<JsInstance>(GetValues());
            string[] values = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    values[i] = list[i].ToString();
            }

            return String.Join(",", values);
        }

        public const string TYPEOF = "object";

        public override string Class
        {
            get { return TYPEOF; }
        }

    }
}
