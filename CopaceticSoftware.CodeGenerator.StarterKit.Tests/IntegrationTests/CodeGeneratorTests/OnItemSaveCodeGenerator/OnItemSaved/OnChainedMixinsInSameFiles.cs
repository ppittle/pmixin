﻿//----------------------------------------------------------------------- 
// <copyright file="OnChainedMixinsInSameFiles.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Monday, September 1, 2014 11:49:33 PM</date> 
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
using CopaceticSoftware.pMixins.Tests.Common;
using NUnit.Framework;

namespace CopaceticSoftware.CodeGenerator.StarterKit.Tests.IntegrationTests.CodeGeneratorTests.OnItemSaveCodeGenerator.OnItemSaved
{
    [FutureRelease]
    [TestFixture]
    public class OnChainedMixinsInSameFiles : CodeBehindFileIsGeneratedWithOnItemSaveCodeGenerator
    {
        private const string InitialFileSource = 
            @"
            namespace Testing{
                public class Mixin{ public int TestMethod(){return 42;} }

                //Chained is intentionally out-of-order
                [CopaceticSoftware.pMixins.Attributes.pMixin(Mixin = typeof(Target))]                                        
                public partial class Chained  {}                

                [CopaceticSoftware.pMixins.Attributes.pMixin(Mixin = typeof(Mixin))]                                        
                public partial class Target  {}                
            }";

        private const string UpdatedFileSource = 
            @"
            namespace Testing{
                public class Mixin{ 
                    public int TestMethod(){return 42;} 
                    public int ChainedMethod(){ return 24;}
                }

                //Chained is intentionally out-of-order
                [CopaceticSoftware.pMixins.Attributes.pMixin(Mixin = typeof(Target))]                                        
                public partial class Chained  {}           

                [CopaceticSoftware.pMixins.Attributes.pMixin(Mixin = typeof(Mixin))]                                        
                public partial class Target  {}
            }";

        protected override void MainSetupInitializeSolution()
        {
            _MockSolution.InitializeWithEmptyProject();

            _MockSolution.Projects[0].MockSourceFiles.Add(new MockSourceFile
            {
                Source = InitialFileSource
            });

            //Fix Project References
            _MockSolution.Projects[0].AssemblyReferences =
                ReferenceHelper.GetDefaultSystemReferences()
                    .Union(new[] { ReferenceHelper.GetReferenceToPMixinsDll() })
                    .ToList();
        }

        public override void MainSetup()
        {
            base.MainSetup();

            //Add a new method to the Mixin class
            this.UpdateMockSourceFileSource(
                _MockSolution.Projects[0].MockSourceFiles[0],
                UpdatedFileSource);
        }

        [Test]
        public void CanExecuteChainedMixedInMethods()
        {
            _MockSolution.Projects[0]
                .AssertCompilesAndCanExecuteMethod(
                    "Testing.Chained",
                    "TestMethod",
                    42);

            _MockSolution.Projects[0]
                .AssertCompilesAndCanExecuteMethod(
                    "Testing.Chained",
                    "ChainedMethod",
                    24);
        }
    }
}
