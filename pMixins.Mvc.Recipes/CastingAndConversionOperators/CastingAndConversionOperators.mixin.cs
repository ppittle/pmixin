//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by CopaceticSoftware.pMixins.CodeGenerator v0.5.1.379
//      for file pMixins\pMixins.Mvc.Recipes\CastingAndConversionOperators\CastingAndConversionOperators.cs.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.  
// </auto-generated> 
//------------------------------------------------------------------------------
namespace pMixins.Mvc.Recipes.CastingAndConversionOperators
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.5.1.379")]
	public partial class CastingAndConversionOperators : global::pMixins.Mvc.Recipes.CastingAndConversionOperators.ISomeInterface, pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin.IMixinRequirements, global::CopaceticSoftware.pMixins.ConversionOperators.IContainMixin<global::pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin>
	{
		private sealed class __Mixins
		{
			public static global::System.Object ____Lock = new global::System.Object ();
			public __pMixinAutoGenerated.pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin.MixinMasterWrapper pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin;
			public __Mixins (CastingAndConversionOperators target)
			{
				pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin = global::CopaceticSoftware.pMixins.Infrastructure.MixinActivatorFactory.GetCurrentActivator ().CreateInstance<__pMixinAutoGenerated.pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin.MixinMasterWrapper> ((pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin.IMixinRequirements)target);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			public void __ActivateMixinDependencies (pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators target)
			{
				pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin.__ActivateMixinDependencies (target);
			}
		}
		private sealed class __pMixinAutoGenerated
		{
			public sealed class pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin
			{
				public class MixinMasterWrapper : global::CopaceticSoftware.pMixins.Infrastructure.MasterWrapperBase
				{
					public MixinMasterWrapper (pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin.IMixinRequirements target)
					{
						_mixinInstance = base.TryActivateMixin<pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin.MixinAbstractWrapper> (target);
						BaseClassMethodFunc = () => _mixinInstance.BaseClassMethod ();
						base.Initialize (target, _mixinInstance, new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.IMixinInterceptor> {

						});
					}
					public global::pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin _mixinInstance;
					public global::System.Func<global::System.String> BaseClassMethodFunc {
						get;
						set;
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					public void __ActivateMixinDependencies (pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators target)
					{
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					internal global::System.String BaseClassMethod ()
					{
						return base.ExecuteMethod ("BaseClassMethod", new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.Parameter> {

						}, () => this.BaseClassMethodFunc ());
					}
					[global::System.Diagnostics.DebuggerStepThrough]
					internal global::System.String InterfaceMethod ()
					{
						return base.ExecuteMethod ("InterfaceMethod", new global::System.Collections.Generic.List<global::CopaceticSoftware.pMixins.Interceptors.Parameter> {

						}, () => _mixinInstance.InterfaceMethod ());
					}
				}
			}
		}
		private __Mixins ____mixins;
		private __Mixins __mixins {
			get {
				if (null == ____mixins) {
					lock (__Mixins.____Lock) {
						if (null == ____mixins) {
							____mixins = new __Mixins (this);
							____mixins.__ActivateMixinDependencies (this);
						}
					}
				}
				return ____mixins;
			}
		}
		global::pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin global::CopaceticSoftware.pMixins.ConversionOperators.IContainMixin<global::pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin>.MixinInstance {
			get {
				return __mixins.pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin._mixinInstance;
			}
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public static implicit operator global::pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin (CastingAndConversionOperators target) {
			return target.__mixins.pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin._mixinInstance;
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public virtual global::System.String BaseClassMethod ()
		{
			return __mixins.pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin.BaseClassMethod ();
		}
		[global::System.Diagnostics.DebuggerStepThrough]
		public global::System.String InterfaceMethod ()
		{
			return __mixins.pMixins_Mvc_Recipes_CastingAndConversionOperators_Mixin.InterfaceMethod ();
		}
	}
}
namespace pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.__Shared
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.5.1.379")]
	public interface ISharedRequirements
	{
	}
}
namespace pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute ("pMixin", "0.5.1.379")]
	public interface IMixinRequirements : global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.__Shared.ISharedRequirements
	{
	}
}
namespace pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin
{
	public abstract class MixinProtectedMembersWrapper : global::pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin
	{
	}
}
namespace pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin
{
	public class MixinAbstractWrapper : MixinProtectedMembersWrapper
	{
		private readonly global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin.IMixinRequirements _target;
		public MixinAbstractWrapper (global::pMixins.AutoGenerated.pMixins.Mvc.Recipes.CastingAndConversionOperators.CastingAndConversionOperators.pMixins.Mvc.Recipes.CastingAndConversionOperators.Mixin.IMixinRequirements target) : base ()
		{
			_target = target;
		}
	}
}
