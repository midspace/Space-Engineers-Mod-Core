namespace MidSpace.MySampleMod.SeModCore
{
    using ProtoBuf;
    using System;
    using System.Globalization;

    /// <summary>
    /// A helper class for converting base types typically stored in a System.Object array,
    /// into something that can be serialized but still in an array.
    /// </summary>
    [ProtoContract]
    public class SerializableArgument
    {
        public enum BaseTypes
        {
            Null,
            Boolean,
            Byte,
            DateTime,
            Decimal,
            Double,
            Int32,
            Int64,
            Single,
            String,
            TimeSpan,
        }

        private Type _type;

        [ProtoMember(1)]
        public BaseTypes BaseType
        {
            get { return GetBaseType(_type); }
            set { _type = GetType(value); }
        }

        [ProtoMember(2)]
        public string Data;

        #region constructors

        public SerializableArgument()
        {
            _type = null;
        }

        public SerializableArgument(object value)
        {
            _type = value?.GetType();
            if (_type == null || value == null)
                Data = null;
            else if (_type == typeof(DateTime))
                Data = ((DateTime)value).ToString("o", CultureInfo.InvariantCulture);
            else if (_type == typeof(TimeSpan))
                Data = ((TimeSpan)value).Ticks.ToString(CultureInfo.InvariantCulture);
            else if (_type == typeof(float))
                Data = ((float)value).ToString("R", CultureInfo.InvariantCulture);
            else if (_type == typeof(double))
                Data = ((double)value).ToString("R", CultureInfo.InvariantCulture);
            else
                Data = Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        #endregion

        public object ToObject()
        {
            if (_type == null)
                return null;
            if (_type == typeof(TimeSpan))
                return new TimeSpan(Convert.ToInt64(Data, CultureInfo.InvariantCulture));
            return Convert.ChangeType(Data, _type, CultureInfo.InvariantCulture);
        }

        public static SerializableArgument[] ToSerializableArguments(object[] arguments)
        {
            SerializableArgument[] list = new SerializableArgument[arguments.Length];
            for (int i = 0; i < arguments.Length; i++)
                list[i] = new SerializableArgument(arguments[i]);

            return list;
        }

        private static BaseTypes GetBaseType(Type type)
        {
            if (type == null)
                return BaseTypes.Null;
            if (type == typeof(bool))
                return BaseTypes.Boolean;
            if (type == typeof(byte))
                return BaseTypes.Byte;
            if (type == typeof(DateTime))
                return BaseTypes.DateTime;
            if (type == typeof(decimal))
                return BaseTypes.Decimal;
            if (type == typeof(double))
                return BaseTypes.Double;
            if (type == typeof(int))
                return BaseTypes.Int32;
            if (type == typeof(long))
                return BaseTypes.Int64;
            if (type == typeof(float))
                return BaseTypes.Single;
            if (type == typeof(string))
                return BaseTypes.String;
            if (type == typeof(TimeSpan))
                return BaseTypes.TimeSpan;

            throw new Exception($"Type {type.FullName} was not expected. Cannot Serialize.");
        }

        private static Type GetType(BaseTypes baseType)
        {
            switch (baseType)
            {
                case BaseTypes.Null: return null;
                case BaseTypes.Boolean: return typeof(bool);
                case BaseTypes.Byte: return typeof(byte);
                case BaseTypes.DateTime: return typeof(DateTime);
                case BaseTypes.Decimal: return typeof(decimal);
                case BaseTypes.Double: return typeof(double);
                case BaseTypes.Int32: return typeof(int);
                case BaseTypes.Int64: return typeof(long);
                case BaseTypes.Single: return typeof(float);
                case BaseTypes.String: return typeof(string);
                case BaseTypes.TimeSpan: return typeof(TimeSpan);
            }

            throw new Exception($"Type {baseType} was not expected. Cannot Serialize.");
        }

        //// allow SerializableArgument to implicitly be converted to and from System.Type
        //static public implicit operator Type(SerializableArgument stype)
        //{
        //    return stype._type;
        //}

        //static public implicit operator SerializableArgument(Type t)
        //{
        //    return new SerializableArgument(t);
        //}
    }
}
