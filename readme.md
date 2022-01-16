# Dapper 

**What's Dapper?**

Dapper is a simple object mapper for .NET and owns the title of **King of Micro ORM** in terms of speed and is virtually as fast as using a raw ADO.NET data  reader. An ORM is an Object Relational Mapper, which is responsible for  mapping between database and programming language.

Dapper extends the IDbConnection by providing useful extension methods to query your database.

**How Dapper Works?**

It is a three-step process.

- Create an IDbConnection object.
- Write a query to perform CRUD operations.
- Pass query as a parameter in the Execute method.

## Installation

Dapper is installed through NuGet: https://www.nuget.org/packages/Dapper

```
PM> Install-Package Dapper
```

## Requirement

Dapper works with any database provider since there is no DB specific implementation.

## Methods

Dapper will extend your IDbConnection interface with multiple methods:

- **Execute**

  支持 `insert, update, delete, stored procedure` 单个或批量操作

- **Execute Reader**

  支持 `select, stored procedure` , 可用于填充 `DataTable` or `DataSet`

- **Execute Scalar**

  支持 `select` , 返回第1行第1列的值

- **Query**

  执行查询, 并将结果映射到实体对象

  `Anonymous` 未指定类型, 返回匿名参数
  `Strongly Typed` 返回指定的强类型参数
  `Multi-Mapping (One to One)` 返回具有1对1关联关系的强类型参数
  `Multi-Mapping (One to Many)` 返回具有1对多关联关系的强类型参数
  `Multi-Type` 返回多种强类型参数

- **QueryFirst**

  返回查询的第1条结果, 没有的话会报错

- **QueryFirstOrDefault**

  返回查询的第1条结果, 没有的话会返回类型的默认值

- **QuerySingle**

  返回查询的唯一结果, 没有或存在多条结果都会报错

- **QuerySingleOrDefault**

  返回查询的唯一结果, 没有的话会返回类型的默认值, 存在多条结果时都会报错

- **QueryMultiple**

  支持多条sql同时执行, 返回对应类型的多个结果

## Utilities

- Async

  支持 `execute` 和 `query` 的异步执行

- Buffered

  控制加载的数据量, 在大查询时可以减少内存占用

- Transaction

  dapper方法都支持传入 `transaction` 参数实现事务

  也可以引用 `Dapper.Transaction` 使用 `IDbTransaction` 的拓展方法

## Dapper Plus

拓展了 `IDbConnection ` 接口, 实现了多个支持批量操作的方法

需引用 `Z.Dapper.Plus` **(收费,允许每月试用)**

更多使用方法请查阅官方文档 https://dapper-plus.net/bulk-insert

- Bulk Insert

  支持批量插入, 支持具有关联关系的多表插入

- Bulk Update

  支持批量更新, 支持具有关联关系的多表更新

- Bulk Delete

  支持批量删除, 支持具有关联关系的多表删除	

- Bulk Merge

  支持同时批量插入和更新**(Upsert)**, 支持具有关联关系的多表操作

## Dapper Contrib

**Methods**

拓展了 `IDbConnection ` 接口, 提供了额外的 `CRUD` 方法

- Get

  按主键查询, 需先指定主键属性

- GetAll

  查询所有结果

- Insert

  支持单个或批量插入实体对象

- Update

  支持单个或批量更新实体对象

- Delete

  支持单个或批量删除实体对象

- DeleteAll

  删除所有结果**(慎用)**

**Data Annotations**

允许使用注解来实现映射

- Key

  自增主键, 由数据库自动赋值

- ExplicitKey

  自定义主键, 需自行填充值

- Table

  映射到实体对象的表名

- Write

  指定字段是否写入数据库, 为False时不写入

  适用于非数据库字段

- Computed

  计算字段, 不会保存到数据库

  适用于非数据库字段

