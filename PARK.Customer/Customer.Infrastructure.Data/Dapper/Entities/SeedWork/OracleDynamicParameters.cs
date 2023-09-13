using Dapper;
using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infrastructure.Dapper.Entities
{
    public class OracleDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters _dynamicParameters = new DynamicParameters();

        private readonly List<Devart.Data.Oracle.OracleParameter> _oracleParameters = new List<Devart.Data.Oracle.OracleParameter>();

        public void Add(string name, object value = null, DbType dbType = DbType.AnsiString, ParameterDirection? direction = null, int? size = null)
        {
            _dynamicParameters.Add(name, value, dbType, direction, size);
        }

        public void Add(string name, OracleType oracleDbType, ParameterDirection direction)
        {
            var oracleParameter = new Devart.Data.Oracle.OracleParameter(name, oracleDbType) { Direction = direction };
            _oracleParameters.Add(oracleParameter);
        }

        public void Add(string name, Devart.Data.Oracle.OracleDbType oracleDbType, int size, ParameterDirection direction)
        {
            var oracleParameter = new Devart.Data.Oracle.OracleParameter(name, oracleDbType, size) { Direction = direction };
            _oracleParameters.Add(oracleParameter);
        }

        internal object Add(string v, Oracle.ManagedDataAccess.Client.OracleDbType blob, int length)
        {
            throw new NotImplementedException();
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)_dynamicParameters).AddParameters(command, identity);

            var oracleCommand = command as Devart.Data.Oracle.OracleCommand;

            if (oracleCommand != null)
            {
                oracleCommand.Parameters.AddRange(_oracleParameters.ToArray());
            }
        }

        public T Get<T>(string parameterName)
        {
            var parameter = _oracleParameters.SingleOrDefault(t => t.ParameterName == parameterName);
            if (parameter != null)
                return (T)Convert.ChangeType(parameter.Value, typeof(T));
            return default(T);
        }

        public T Get<T>(int index)
        {
            var parameter = _oracleParameters[index];
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
                throw new InvalidOperationException("If specifying IsFixedLength,  a Length must also be specified");
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
