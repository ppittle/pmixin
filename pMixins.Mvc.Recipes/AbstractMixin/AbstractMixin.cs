﻿//----------------------------------------------------------------------- 
// <copyright file="AbstractMixin.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Friday, July 4, 2014 5:05:24 PM</date> 
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

using CopaceticSoftware.pMixins.Attributes;
using NUnit.Framework;
using pMixins.AutoGenerated.pMixins.Mvc.Recipes.AbstractMixin.AbstractMixinExample.pMixins.Mvc.Recipes.AbstractMixin.PrinterMixin;

namespace pMixins.Mvc.Recipes.AbstractMixin
{
    public abstract class PrinterMixin
    {
        public abstract string Name { get; }

        public string PrintName()
        {
            return "Hi My Name is " + Name;
        }
    }

    [pMixin(Mixin = typeof(PrinterMixin))]
    public partial class AbstractMixinExample 
    {
        string IPrinterMixinRequirements.NameImplementation
        {
            get { return "pMixins"; }
        }
    }
    
    [TestFixture]
    public class AbstractMixinTest
    {
        [Test]
        public void CanCallAbstractProperty()
        {
            Assert.AreEqual(
                "pMixins",
                new AbstractMixinExample().Name);
        }

        [Test]
        public void CanPrintName()
        {
            Assert.AreEqual(
                "Hi My Name is pMixins",
                new AbstractMixinExample().PrintName());
        }
    }
}
