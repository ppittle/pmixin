﻿//----------------------------------------------------------------------- 
// <copyright file="ResolveInterceptorMixinRequirements.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, August 20, 2014 3:00:11 PM</date> 
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

using System.Linq;
using CopaceticSoftware.CodeGenerator.StarterKit.Extensions;
using CopaceticSoftware.Common.Patterns;
using CopaceticSoftware.pMixins.Attributes;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.ResolveAttributes.Infrastructure;
using ICSharpCode.NRefactory.TypeSystem;

namespace CopaceticSoftware.pMixins.CodeGenerator.Pipelines.ResolveAttributes.Steps
{
    public class ResolveInterceptorMixinRequirements : IPipelineStep<IResolveAttributesPipelineState>
    {
        public bool PerformTask(IResolveAttributesPipelineState manager)
        {
            foreach (var classAtts in manager.CommonState.SourcePartialClassAttributes)
            {
                var allMixinAttributes = manager.PartialClassLevelResolvedPMixinAttributes[classAtts.Key]
                    .OfType<pMixinAttributeResolvedResult>()
                    .ToList();


                var interceptors = allMixinAttributes.SelectMany(x => x.Interceptors);

                var interceptorRequiredAttributes =
                    interceptors
                        .SelectMany(x => x.GetAttributes())
                        .Where(a => a.AttributeType.Implements<InterceptorMixinRequirementAttribute>());

                var mixinsToAdd =
                    interceptorRequiredAttributes
                        .Select(x => ResolveMixinType(x, manager))
                        .Where(x => x != null)
                        .Distinct()
                        .Where(x => !allMixinAttributes.Select(a => a.Mixin).Contains(x));


                foreach (var mixin in mixinsToAdd)
                {
                    manager.PartialClassLevelResolvedPMixinAttributes[classAtts.Key]
                        .Add(new pMixinAttributeResolvedResult(null){Mixin = mixin});
                }
            }

            return true;
        }

        private IType ResolveMixinType(IAttribute attribute, IResolveAttributesPipelineState manager)
        {
            IType result = null;

            manager.TypeInstanceActivator.TryCreateInstance<pMixinAttributeResolvedResult>(
                attribute,
                instance =>
                {
                    try
                    {
                        result = instance.Mixin;
                    }
                    catch
                    {
                    }
                });

            if (null != result)
                return result;

            return attribute.GetNamedArgumentValue("Mixin") as IType;
        }
    }
}
