using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Infrastructure.Dapper.Entities
{
    public class MySqlDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters _dynamicParameters = new DynamicParameters();
        private readonly List<MySql.Data.MySqlClient.MySqlParameter> _mySqlParameters = new List<MySql.Data.MySqlClient.MySqlParameter>();

        public void Add(string name, object value = null, DbType dbType = DbType.AnsiString, ParameterDirection? direction = null, int? size = null)
        {
            _dynamicParameters.Add(name, value, dbType, direction, size);
        }

        public void Add(string name, MySql.Data.MySqlClient.MySqlDbType mySqlDbType, ParameterDirection direction)
        {
            var mySqlParameter = new MySql.Data.MySqlClient.MySqlParameter(name, mySqlDbType) { Direction = direction };
            _mySqlParameters.Add(mySqlParameter);
        }

        public void Add(string name, MySql.Data.MySqlClient.MySqlDbType mySqlDbType, int size, ParameterDirection direction)
        {
            var mySqlParameter = new MySql.Data.MySqlClient.MySqlParameter(name, mySqlDbType, size) { Direction = direction };
            _mySqlParameters.Add(mySqlParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)_dynamicParameters).AddParameters(command, identity);

            var mySqlCommand = command as MySql.Data.MySqlClient.MySqlCommand;

            if (mySqlCommand != null)
            {
                mySqlCommand.Parameters.AddRange(_mySqlParameters.ToArray());
            }
        }

        public T Get<T>(string parameterName)
        {
            var parameter = _mySqlParameters.SingleOrDefault(t => t.ParameterName == parameterName);
            if (parameter != null)
                return (T)Convert.ChangeType(parameter.Value, typeof(T));
            return default(T);
        }

        public T Get<T>(int index)
        {
            var parameter = _mySqlParameters[index];
            if (parameter != null)
                return (T)Convert.ChangeType(parameter.Value, typeof(T));
            return default(T);
        }
    }

    public sealed class DbString
    {
        public DbString() { Length = -1; }
        public bool IsAnsi { get; set; }
        public bool IsFixedLength { get; set; }
        public int Length { get; set; }
        public string Value { get; set; }
        public void AddParameter(IDbCommand command, string name)
        {
            if (IsFixedLength && Length == -1)
            {
                throw new InvalidOperationException("If specifying IsFixedLength, a Length must also be specified");
            }
            var param = command.CreateParameter();
            param.ParameterName = name;
            param.Value = (object)Value ?? DBNull.Value;
            if (Length == -1 && Value != null && Value.Length <= 4000)
            {
                param.Size = 4000;
            }
            else
            {
                param.Size = Length;
            }
            param.DbType = IsAnsi ? (IsFixedLength ? DbType.AnsiStringFixedLength : DbType.AnsiString) : (IsFixedLength ? DbType.StringFixedLength : DbType.String);
            command.Parameters.Add(param);
        }
    }
}
