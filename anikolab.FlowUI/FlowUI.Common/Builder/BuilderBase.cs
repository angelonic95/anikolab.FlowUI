using System;
using System.Collections.Generic;
using System.Text;
using FlowUI.Common.Common;
using FlowUI.Common.Model;

namespace FlowUI.Common.Builder
{
	public abstract class BuilderBase<T, TForm, TRibbon, TSubgrid> : Builder<T> where T : class where TForm : class, new() where TRibbon : class, new() where TSubgrid : class, new()
	{
		protected TForm formConfiguration;
		protected TRibbon ribbonConfiguration;
		protected TSubgrid subgridConfiguration;
		protected T _instance;
		protected EntityConfiguration<TForm, TRibbon, TSubgrid> entityConfiguration;

		public BuilderBase()
		{
			this.formConfiguration = new TForm();
			this.ribbonConfiguration = new TRibbon();
			this.subgridConfiguration = new TSubgrid();
			this._instance = this as T;
		}

		public BuilderBase<T, TForm, TRibbon, TSubgrid> Build()
		{
			entityConfiguration = new EntityConfiguration<TForm, TRibbon, TSubgrid>(
				this.formConfiguration,
				this.ribbonConfiguration,
				this.subgridConfiguration
			);
			return this;


		}

		public T IsVisible(object entity, string propertyName, bool isVisible)
		{
			var entityType = entity.GetType();
			var property = entityType.GetProperty(propertyName);
			if (property != null && property.CanWrite)
			{
				property.SetValue(entity, isVisible);
			}
			else
			{
				throw new ArgumentException($"Property '{propertyName}' not found or cannot be written to.");
			}
			return _instance;
		}

		public T IsVisible<TEntity>(ref TEntity entity, string propertyName, bool isVisible) where TEntity : class, new()
		{
			if (entity == null)
			{
				entity = new TEntity();
			}
			var entityType = typeof(TEntity);
			var property = entityType.GetProperty(propertyName);

			if (property != null && property.CanWrite)
			{
				property.SetValue(entity, isVisible);
			}
			else
			{
				throw new ArgumentException($"Property '{propertyName}' not found or cannot be written to in type '{entityType.Name}'.");
			}

			return _instance;
		}


		public virtual string AsJson()
		{
			return entityConfiguration.ToJson();
		}

	}
}
