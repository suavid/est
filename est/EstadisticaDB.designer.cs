﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace est
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Estadistica")]
	public partial class EstadisticaDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public EstadisticaDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["EstadisticaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public EstadisticaDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EstadisticaDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EstadisticaDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EstadisticaDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaActividad")]
		public ISingleResult<AsistenciaActividadResult> AsistenciaActividad([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaActividadResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaActividad_Fechas")]
		public ISingleResult<AsistenciaActividad_FechasResult> AsistenciaActividad_Fechas([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaActividad_FechasResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaDevocional")]
		public ISingleResult<AsistenciaDevocionalResult> AsistenciaDevocional([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaDevocionalResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaDevocional_Fechas")]
		public ISingleResult<AsistenciaDevocional_FechasResult> AsistenciaDevocional_Fechas([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaDevocional_FechasResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaEscuela_Fechas")]
		public ISingleResult<AsistenciaEscuela_FechasResult> AsistenciaEscuela_Fechas([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaEscuela_FechasResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaVigilia")]
		public ISingleResult<AsistenciaVigiliaResult> AsistenciaVigilia([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaVigiliaResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaVigilia_Fechas")]
		public ISingleResult<AsistenciaVigilia_FechasResult> AsistenciaVigilia_Fechas([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaVigilia_FechasResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaActividadEspecial")]
		public ISingleResult<AsistenciaActividadEspecialResult> AsistenciaActividadEspecial([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaActividadEspecialResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaActividadEspecial_Fechas")]
		public ISingleResult<AsistenciaActividadEspecial_FechasResult> AsistenciaActividadEspecial_Fechas([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaActividadEspecial_FechasResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaPromedio")]
		public ISingleResult<AsistenciaPromedioResult> AsistenciaPromedio([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaPromedioResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AsistenciaEscuela")]
		public ISingleResult<AsistenciaEscuelaResult> AsistenciaEscuela([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<AsistenciaEscuelaResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.PorcentajeSinRetirarse")]
		public ISingleResult<PorcentajeSinRetirarseResult> PorcentajeSinRetirarse([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaInicio", DbType="Date")] System.Nullable<System.DateTime> fechaInicio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaFin", DbType="Date")] System.Nullable<System.DateTime> fechaFin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fechaInicio, fechaFin);
			return ((ISingleResult<PorcentajeSinRetirarseResult>)(result.ReturnValue));
		}
	}
	
	public partial class AsistenciaActividadResult
	{
		
		private System.Nullable<int> _Cantidad;
		
		public AsistenciaActividadResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int")]
		public System.Nullable<int> Cantidad
		{
			get
			{
				return this._Cantidad;
			}
			set
			{
				if ((this._Cantidad != value))
				{
					this._Cantidad = value;
				}
			}
		}
	}
	
	public partial class AsistenciaActividad_FechasResult
	{
		
		private System.Nullable<System.DateTime> _Fecha;
		
		public AsistenciaActividad_FechasResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date")]
		public System.Nullable<System.DateTime> Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this._Fecha = value;
				}
			}
		}
	}
	
	public partial class AsistenciaDevocionalResult
	{
		
		private System.Nullable<int> _Cantidad;
		
		public AsistenciaDevocionalResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int")]
		public System.Nullable<int> Cantidad
		{
			get
			{
				return this._Cantidad;
			}
			set
			{
				if ((this._Cantidad != value))
				{
					this._Cantidad = value;
				}
			}
		}
	}
	
	public partial class AsistenciaDevocional_FechasResult
	{
		
		private System.Nullable<System.DateTime> _Fecha;
		
		public AsistenciaDevocional_FechasResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date")]
		public System.Nullable<System.DateTime> Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this._Fecha = value;
				}
			}
		}
	}
	
	public partial class AsistenciaEscuela_FechasResult
	{
		
		private System.DateTime _Fecha;
		
		public AsistenciaEscuela_FechasResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date NOT NULL")]
		public System.DateTime Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this._Fecha = value;
				}
			}
		}
	}
	
	public partial class AsistenciaVigiliaResult
	{
		
		private System.Nullable<int> _Cantidad;
		
		public AsistenciaVigiliaResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int")]
		public System.Nullable<int> Cantidad
		{
			get
			{
				return this._Cantidad;
			}
			set
			{
				if ((this._Cantidad != value))
				{
					this._Cantidad = value;
				}
			}
		}
	}
	
	public partial class AsistenciaVigilia_FechasResult
	{
		
		private System.Nullable<System.DateTime> _Fecha;
		
		public AsistenciaVigilia_FechasResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date")]
		public System.Nullable<System.DateTime> Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this._Fecha = value;
				}
			}
		}
	}
	
	public partial class AsistenciaActividadEspecialResult
	{
		
		private System.Nullable<int> _Cantidad;
		
		public AsistenciaActividadEspecialResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int")]
		public System.Nullable<int> Cantidad
		{
			get
			{
				return this._Cantidad;
			}
			set
			{
				if ((this._Cantidad != value))
				{
					this._Cantidad = value;
				}
			}
		}
	}
	
	public partial class AsistenciaActividadEspecial_FechasResult
	{
		
		private System.Nullable<System.DateTime> _Fecha;
		
		public AsistenciaActividadEspecial_FechasResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date")]
		public System.Nullable<System.DateTime> Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this._Fecha = value;
				}
			}
		}
	}
	
	public partial class AsistenciaPromedioResult
	{
		
		private System.Nullable<int> _Cantidad;
		
		public AsistenciaPromedioResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int")]
		public System.Nullable<int> Cantidad
		{
			get
			{
				return this._Cantidad;
			}
			set
			{
				if ((this._Cantidad != value))
				{
					this._Cantidad = value;
				}
			}
		}
	}
	
	public partial class AsistenciaEscuelaResult
	{
		
		private System.Nullable<int> _Total;
		
		public AsistenciaEscuelaResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Total", DbType="Int")]
		public System.Nullable<int> Total
		{
			get
			{
				return this._Total;
			}
			set
			{
				if ((this._Total != value))
				{
					this._Total = value;
				}
			}
		}
	}
	
	public partial class PorcentajeSinRetirarseResult
	{
		
		private System.Nullable<decimal> _y;
		
		private System.Nullable<decimal> _name;
		
		public PorcentajeSinRetirarseResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_y", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> y
		{
			get
			{
				return this._y;
			}
			set
			{
				if ((this._y != value))
				{
					this._y = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
