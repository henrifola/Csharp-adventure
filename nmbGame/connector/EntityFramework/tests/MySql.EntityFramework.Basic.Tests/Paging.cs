// Copyright (c) 2014, 2017, Oracle and/or its affiliates. All rights reserved.
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

using System.Data;
using System.Linq;
using Xunit;

namespace MySql.Data.EntityFramework.Tests
{
  public class Paging : IClassFixture<DefaultFixture>
  {
    private DefaultFixture st;

    public Paging(DefaultFixture fixture)
    {
      st = fixture;
      if (st.Setup(this.GetType()))
        LoadData();
    }

    void LoadData()
    {
      using (DefaultContext ctx = new DefaultContext(st.ConnectionString))
      {
        ctx.Products.Add(new Product() { Name = "Garbage Truck", MinAge = 8 });
        ctx.Products.Add(new Product() { Name = "Fire Truck", MinAge = 12 });
        ctx.Products.Add(new Product() { Name = "Hula Hoop", MinAge = 18 });
        ctx.SaveChanges();
      }
    }

    [Fact]
    public void Take()
    {
      using (DefaultContext ctx = new DefaultContext(st.ConnectionString))
      {
        var q = ctx.Books.Take(2);
        var sql = q.ToString();
        st.CheckSql(sql,
          @"SELECT `Id`, `Name`, `PubDate`, `Pages`, `Author_Id` FROM `Books` LIMIT 2");
      }
    }

    [Fact]
    public void Skip()
    {
      using (DefaultContext ctx = new DefaultContext(st.ConnectionString))
      {
        var q = ctx.Books.OrderBy(b=>b.Pages).Skip(3);
        var sql = q.ToString();
        st.CheckSql(sql,
          @"SELECT `Extent1`.`Id`, `Extent1`.`Name`, `Extent1`.`PubDate`, `Extent1`.`Pages`, `Extent1`.`Author_Id`
            FROM `Books` AS `Extent1` ORDER BY `Extent1`.`Pages` ASC LIMIT 3,18446744073709551615");
      }
    }

    [Fact]
    public void SkipAndTakeSimple()
    {
      using (DefaultContext ctx = new DefaultContext(st.ConnectionString))
      {
        var q = ctx.Books.OrderBy(b => b.Pages).Skip(3).Take(4);
        var sql = q.ToString();
        st.CheckSql(sql,
          @"SELECT `Extent1`.`Id`, `Extent1`.`Name`, `Extent1`.`PubDate`, `Extent1`.`Pages`, `Extent1`.`Author_Id`
            FROM `Books` AS `Extent1` ORDER BY `Extent1`.`Pages` ASC LIMIT 3,4");
      }
    }

    // <summary>
    // Tests fix for bug #64749 - Entity Framework - Take().Count() fails with EntityCommandCompilationException.
    // </summary>
    [Fact]
    public void TakeWithCount()
    {
      using (DefaultContext ctx = new DefaultContext(st.ConnectionString))
      {
        int cnt = ctx.Products.Take(2).Count();
        Assert.Equal(2, cnt);
      }
    }
  }
}