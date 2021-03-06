﻿//----------------------------------------------------------------------- 
// <copyright file="ExampleCodeBehind.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, July 9, 2014 10:52:31 PM</date> 
// Licensed under the Apache License, Version 2.0,
// you may not use this file except in compliance with this License.
//  
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an 'AS IS' BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright> 
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaceticSoftware.pMixins.ConversionOperators;

namespace pMixins.Mvc.Recipes.Introduction.ExampleCodeBehind
{
    public class HelloWorld
    {
        public string SayHello()
        {
            return "Copy";
        }
    }

    public partial class Introduction
    {
        /// <summary>
        /// Container for all Generated Mixin Wrapper Class Definitions
        /// </summary>
        private sealed class __pMixinAutoGenerated
        {
            /// <summary>
            /// Container for Hello World Specific Wrappers
            /// </summary>
            public sealed class HelloWorldMixin
            {
                /// <summary>
                /// Promote Protected Members to Public.  pMixins will enforce
                /// access restrictions.
                /// </summary>
                public abstract class HelloWorldProtectedMembersWrapper : HelloWorld { }

                /// <summary>
                /// Satisfies any abstract member requirements by proxying to 
                /// Target.
                /// </summary>
                public class HelloWorldAbstractWrapper : HelloWorldProtectedMembersWrapper
                {
                    private readonly Introduction _target;

                    public HelloWorldAbstractWrapper(Introduction target)
                    {
                        _target = target;
                    }
                }

                public sealed class HelloWorldMasterWrapper : CopaceticSoftware.pMixins.Infrastructure.MasterWrapperBase
                {
                    public readonly HelloWorld _mixinInstance;

                    public HelloWorldMasterWrapper(Introduction _target)
                    {
                        _mixinInstance = base.TryActivateMixin<HelloWorldAbstractWrapper>(_target);

                        base.Initialize(_target, _mixinInstance, new List<CopaceticSoftware.pMixins.Interceptors.IMixinInterceptor>());
                    }


                    internal string SayHello()
                    {
                        var methodName = "SayHello";
                        var parameters = new List<CopaceticSoftware.pMixins.Interceptors.Parameter>();
                        Func<string> invocationDelegate = () => _mixinInstance.SayHello();

                        //Wire into AOP Infrastructure
                        return base.ExecuteMethod(
                            methodName,
                            parameters,
                            invocationDelegate);
                    }
                }
            }
        }

        /// <summary>
        /// Container for Mixin instances
        /// </summary>
        private sealed class __Mixins
		{
            //Instance of Hello World 
            public readonly __pMixinAutoGenerated.HelloWorldMixin.HelloWorldMasterWrapper _HelloWorld;

			public __Mixins (Introduction host)
			{
			    var activator =
			        CopaceticSoftware.pMixins.Infrastructure.MixinActivatorFactory.GetCurrentActivator();

				_HelloWorld = 
                    activator.CreateInstance<
                        __pMixinAutoGenerated.HelloWorldMixin.HelloWorldMasterWrapper>(host);
			}
		}

        private __Mixins ___mixinsBacking;
        private __Mixins __mixins
        {
            get { return ___mixinsBacking ?? (___mixinsBacking = new __Mixins(this)); }
        }

        /// <summary>
        /// Mixed in from HelloWorld.SayHello()
        /// </summary>
        public string SayHello()
        {
            return __mixins._HelloWorld.SayHello();
        }

        public static implicit operator HelloWorld(Introduction target)
        {
            return target.__mixins._HelloWorld._mixinInstance;
        }
    }
}
