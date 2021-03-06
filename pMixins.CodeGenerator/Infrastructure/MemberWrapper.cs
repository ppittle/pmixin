﻿//----------------------------------------------------------------------- 
// <copyright file="MemberWrapper.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, July 23, 2014 10:15:58 AM</date> 
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

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CopaceticSoftware.CodeGenerator.StarterKit.Extensions;
using CopaceticSoftware.pMixins.Attributes;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.MixinLevelCodeGenerator.Steps.GenerateMembers;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.ResolveAttributes.Infrastructure;
using ICSharpCode.NRefactory.TypeSystem;

namespace CopaceticSoftware.pMixins.CodeGenerator.Infrastructure
{
    /// <summary>
    /// Provides a structure for wrapping 
    /// <see cref="IMember"/>s with Mixin 
    /// specific context.
    /// </summary>
    [DebuggerDisplay("{Member} - {DeclaringType.Name}")]
    public class MemberWrapper
    {
        public MemberWrapper(MemberImplementationDetails implementationDetails = null)
        {
            if (null == implementationDetails)
                implementationDetails = new MemberImplementationDetails();

            ImplementationDetails = implementationDetails;

            ImplementationDetails.ParentMemberWrapper = this;
        }

        /// <summary>
        /// Reference to the original member
        /// </summary>
        public IMember Member { get; set; }

        /// <summary>
        /// The Mixin associated with this Member
        /// </summary>
        public pMixinAttributeResolvedResult MixinAttribute { get; set; }

        /// <summary>
        /// The Type that originally declared this 
        /// member.  Can be the <see cref="MixinAttribute"/> or
        /// one of its parent classes.
        /// </summary>
        public IType DeclaringType { get; set; }

        public MemberImplementationDetails ImplementationDetails { get; private set; }
    }

    public class MemberImplementationDetails
    {
        /// <summary>
        /// The Parent <see cref="MemberWrapper"/> this 
        /// <see cref="MemberImplementationDetails"/> is 
        /// associated with.
        /// </summary>
        public MemberWrapper ParentMemberWrapper { get; set; }

        /// <summary>
        /// The name of the <see cref="ParentMemberWrapper"/> when added
        /// to the Requirements Implementation name.
        /// </summary>
        /// <remarks>
        /// Referenced by 
        /// <see cref="GenerateAbstractWrapperMembers.ProcessMembers"/>
        /// </remarks>
        public string RequirementsInterfaceImplementationName { get; set; }

        /// <summary>
        /// If the <see cref="ParentMemberWrapper"/> is protected and abstract,
        /// a special wrapper member needs to be created in order
        /// to promote the member to public in the 
        /// Abstract Wrapper.
        /// </summary>
        public string ProtectedAbstractMemberPromotedToPublicMemberName { get; set; }

        /// <summary>
        /// The name of the function that can be overloaded to simulate
        /// support for virtual mixin members.
        /// </summary>
        public string VirtualMemberFunctionName
        {
            get { return ParentMemberWrapper.Member.Name + "Func"; }
        }

        /// <summary>
        /// Instructs the Code Generation Pipeline to implement 
        /// the member as <c>abstract</c> when added to the Target.
        /// </summary>
        /// <remarks>
        /// This is in response to <see cref="pMixinAttribute.KeepAbstractMembersAbstract"/>
        /// </remarks>
        public bool ImplementInTargetAsAbstract { get; set; }

        /// <summary>
        /// Get or Sets an Interface that should be used
        /// to implement this interface explicitly.
        /// </summary>
        public IType ExplicitInterfaceImplementationType { get; set; }

        public bool ImplementExplicitly { get { return null != ExplicitInterfaceImplementationType; } }
    }
}
