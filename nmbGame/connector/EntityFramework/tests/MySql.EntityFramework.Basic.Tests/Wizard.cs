// Copyright (c) 2014, 2019, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License, version 2.0, as
// published by the Free Software Foundation.
//
// This program is also distributed with certain software (including
// but not limited to OpenSSL) that is licensed under separate terms,
// as designated in a particular file or component or in included license
// documentation.  The authors of MySQL hereby grant you an
// additional permission to link the program and your derivative works
// with the separately licensed software that they have included with
// MySQL.
//
// Without limiting anything contained in the foregoing, this file,
// which is part of MySQL Connector/NET, is also subject to the
// Universal FOSS Exception, version 1.0, a copy of which can be found at
// http://oss.oracle.com/licenses/universal-foss-exception.
//
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License, version 2.0, for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System;
using MySql.Data.MySqlClient;
using System.Data.Entity.Core.Common;
using System.Xml;
using Xunit;


namespace MySql.Data.EntityFramework.Tests
{
  // This test unit covers the tests that the wizard runs when generating a model
  // from an existing database
  public class WizardTests : IClassFixture<DefaultFixture>
  {
    private DefaultFixture st;

    public WizardTests(DefaultFixture data)
    {
      st = data;
      st.Setup(this.GetType());
    }

    [Fact]
    public void GetDbProviderManifestTokenReturnsCorrectSchemaVersion()
    {
      MySqlProviderServices services = new MySqlProviderServices();
      string token = services.GetProviderManifestToken(st.Connection);

      if (st.Version < new Version(5, 1))
        Assert.Equal("5.0", token);
      else if (st.Version < new Version(5, 5))
        Assert.Equal("5.1", token);
      else if (st.Version < new Version(5, 6))
        Assert.Equal("5.5", token);
      else if (st.Version < new Version(5, 7))
        Assert.Equal("5.6", token);
      else if (st.Version < new Version(8, 0))
        Assert.Equal("5.7", token);
      else
        Assert.Equal("8.0", token);
    }

    [Fact]
    public void GetStoreSchemaDescriptionDoesNotThrowForServer50OrGreater()
    {
      MySqlProviderManifest manifest = new MySqlProviderManifest(st.Version.Major + "." + st.Version.Minor);
      using (XmlReader reader = manifest.GetInformation(DbXmlEnabledProviderManifest.StoreSchemaDefinition))
      {
        Assert.NotNull(reader);
      }
    }
  }
}