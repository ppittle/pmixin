﻿//----------------------------------------------------------------------- 
// <copyright file="CreateTargetCodeBehindTypeDeclaration.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, July 23, 2014 11:34:24 AM</date> 
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

using CopaceticSoftware.CodeGenerator.StarterKit.Extensions;
using CopaceticSoftware.Common.Patterns;
using CopaceticSoftware.pMixins.CodeGenerator.Infrastructure;
using CopaceticSoftware.pMixins.CodeGenerator.Infrastructure.CodeGeneratorProxy;
using ICSharpCode.NRefactory.CSharp;

namespace CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.TargetLevelCodeGenerator.Steps.CreateTypeDeclarations
{
    /// <summary>
    /// Creates the Target's class declaration for the code behind file and 
    /// saves it in <see cref="TargetLevelCodeGeneratorPipelineState.TargetCodeBehindTypeDeclaration"/>.
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// //Source:
    /// [pMixin(Mixin = typeof(Mixin)]
    /// public partial class Target{}
    /// 
    /// //Generates:
    /// public partial class Target{}
    /// ]]>
    /// </code>
    /// </example>
    public class CreateTargetCodeBehindTypeDeclaration : IPipelineStep<TargetLevelCodeGeneratorPipelineState>
    {
        public bool PerformTask(TargetLevelCodeGeneratorPipelineState manager)
        {
            var targetCodeBehind =
                new TypeDeclaration
                    {
                        ClassType = ClassType.Class,
                        Modifiers = manager.TargetSourceTypeDeclaration.Modifiers, // this should include partial
                        Name = manager.TargetSourceTypeDeclaration.Name
                    };
            
            var codeGenerator = 
                new CodeGeneratorProxy(
                    targetCodeBehind, 
                    addCodeGeneratedAttribute: true);

            //implement TargetCodeBehindPlan.MixinInterfaces
            manager.CodeGenerationPlan.TargetCodeBehindPlan.MixinInterfaces
                .Map(i => codeGenerator.ImplementInterface(i.GetOriginalFullNameWithGlobal()));

            //Save targetCodeBehind to state
            manager.TargetCodeBehindTypeDeclaration = targetCodeBehind;


            //Add targetCodeGehind to Syntax Tree
            manager.CodeBehindSyntaxTree.AddChildTypeDeclaration
                (targetCodeBehind, 
                    manager.TargetSourceTypeDeclaration.GetParent<NamespaceDeclaration>());

            return true;
        }
    }
}
