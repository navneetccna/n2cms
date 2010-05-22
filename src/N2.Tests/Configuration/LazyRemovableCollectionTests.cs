﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using N2.Configuration;

namespace N2.Tests.Configuration
{
	public class NamedCollectionTester : LazyRemovableCollection<NamedElement>
	{
	}

	[TestFixture]
	public class LazyRemovableCollectionTests
	{
		[Test]
		public void CanAddElement()
		{
			NamedCollectionTester assemblies = new NamedCollectionTester();
			assemblies.Add(new NamedElement { Name = "N2" });

			Assert.That(assemblies.AddedElements.Count(), Is.EqualTo(1));
			Assert.That(assemblies.AddedElements.First().Name, Is.EqualTo("N2"));
		}

		[Test]
		public void CanAddDefaultElement()
		{
			NamedCollectionTester assemblies = new NamedCollectionTester();
			assemblies.AddDefault(new NamedElement { Name = "N2" });

			Assert.That(assemblies.AddedElements.Count(), Is.EqualTo(1));
			Assert.That(assemblies.AddedElements.First().Name, Is.EqualTo("N2"));
		}

		[Test]
		public void CanRemoveElement()
		{
			NamedCollectionTester assemblies = new NamedCollectionTester();
			assemblies.Add(new NamedElement { Name = "N2" });
			assemblies.Remove(new NamedElement { Name = "N2" });

			Assert.That(assemblies.AddedElements.Count(), Is.EqualTo(0));
		}

		[Test]
		public void CanRemoveDefaultElement()
		{
			NamedCollectionTester assemblies = new NamedCollectionTester();
			assemblies.AddDefault(new NamedElement { Name = "N2" });
			assemblies.Remove(new NamedElement { Name = "N2" });

			Assert.That(assemblies.AddedElements.Count(), Is.EqualTo(0));
		}

		[Test]
		public void CanClearElement()
		{
			NamedCollectionTester assemblies = new NamedCollectionTester();
			assemblies.Add(new NamedElement { Name = "N2" });
			assemblies.Clear();

			Assert.That(assemblies.AddedElements.Count(), Is.EqualTo(0));
			Assert.That(assemblies.IsCleared);
		}

		[Test]
		public void CanClearDefaultElement()
		{
			NamedCollectionTester assemblies = new NamedCollectionTester();
			assemblies.AddDefault(new NamedElement { Name = "N2" });
			assemblies.Clear();

			Assert.That(assemblies.AddedElements.Count(), Is.EqualTo(0));
			Assert.That(assemblies.IsCleared);
		}
	}
}