package com.misterfat.generator.tool.db.product;

import java.io.Serializable;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.misterfat.generator.tool.db.Database;
import com.misterfat.generator.tool.db.Table;
import com.misterfat.generator.tool.util.ArrayUtil;
import com.misterfat.generator.tool.util.DBUtil;
import com.misterfat.generator.tool.util.LogUtil;

public class MysqlDatabase extends Database implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = -4688406681725187686L;

	public static final String DRIVER = "com.microsoft.sqlserver.jdbc.SQLServerDriver";

	@Override
	protected String getDriver() {
		return DRIVER;
	}

	/**
	 * 
	 * 功能描述：Map列表转Table列表
	 *
	 * @param tableList
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年6月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public List<Table> convertToTableList(List<Map<String, Object>> tableList) {
		List<Table> tempTableList = new ArrayList<Table>();

		for (int j = 0; j < tableList.size(); j++) {
			Map<String, Object> tablemap = tableList.get(j);
			String tableName = (String) tablemap.get("table_name");
			String tableComment = (String) tablemap.get("table_comment");
			String tableType = (String) tablemap.get("table_type");

			Table table = new Table();
			table.setDatabase(this);
			table.setName(tableName);
			table.setComment(tableComment);
			table.setType(tableType);
			tempTableList.add(table);
		}
		return tempTableList;
	}

	/**
	 * 
	 * 功能描述：查询表的相关信息
	 *
	 * @param tableNames
	 * @return {table_schema,table_name,table_type,table_comment}
	 * @throws SQLException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月19日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Override
	public List<Table> getTalbes(String... tableNames) throws SQLException {
		// 连接数据库
		DBUtil.initDataSource(DRIVER, getUrl(), getUsername(), getPassword());

		// 查询表信息的SQL
		/*
			String findTableSql = "SELECT f.* FROM  ( SELECT t.TABLE_SCHEMA  as table_schema, t.TABLE_NAME as table_name, 'TABLE' as table_type,t.TABLE_COMMENT as table_comment FROM information_schema.tables as t  where t.TABLE_SCHEMA = '"		 
				+ this.schema + "' AND t.TABLE_NAME in (" + ArrayUtil.join(tableNames, ",", "'", "'") + ") ) f ";
		*/

		String findTableSql = "SELECT t.TABLE_CATALOG AS table_schema,t.TABLE_NAME table_name,'TABLE' as table_type FROM sysobjects obj INNER JOIN INFORMATION_SCHEMA.TABLES t ON obj.name = t.TABLE_NAME WHERE obj.xtype = 'U' AND TABLE_NAME IN (" + ArrayUtil.join(tableNames, ",", "'", "'") + ") ";

		LogUtil.log(findTableSql);

		// 表信息列表
		List<Map<String, Object>> tableList = DBUtil.executeQuery(findTableSql);

		this.tableList = convertToTableList(tableList);
		return this.tableList;

	}

	/**
	 * 
	 * 功能描述：查询库中所有表
	 *
	 * @param tableNames
	 * @return {table_schema,table_name,table_type,table_comment}
	 * @throws SQLException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月19日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Override
	public List<Table> getAllTalbes() throws SQLException {
		// 连接数据库
		DBUtil.initDataSource(DRIVER, getUrl(), getUsername(), getPassword());

		// 查询表信息的SQL
		String findTableSql = "SELECT f.* FROM  ( SELECT t.TABLE_SCHEMA  as table_schema, t.TABLE_NAME as table_name, 'TABLE' as table_type,t.TABLE_COMMENT as table_comment FROM information_schema.tables as t  where t.TABLE_SCHEMA = '"
				+ this.schema + "') f ";

		LogUtil.log(findTableSql);

		// 表信息列表
		List<Map<String, Object>> tableList = DBUtil.executeQuery(findTableSql);

		this.tableList = convertToTableList(tableList);
		return this.tableList;
	}

	/**
	 * 
	 * 功能描述：查询主键
	 *
	 * @param table
	 * @return
	 * @throws SQLException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月19日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public List<Map<String, Object>> queryPrimarykeys(String table) throws SQLException {

		StringBuffer sql = new StringBuffer();

		/*
		sql.append("SELECT f.* "
				+ "FROM  ( SELECT k.COLUMN_NAME FROM information_schema.table_constraints t LEFT JOIN information_schema.key_column_usage k USING(constraint_name,table_schema,table_name) "
				+ "WHERE t.constraint_type='PRIMARY KEY' AND t.table_schema='" + this.schema + "' AND t.table_name='"
				+ table + "' ) f");
		*/
		sql.append("SELECT syscolumns.name COLUMN_NAME ");
		sql.append("FROM syscolumns,sysobjects,sysindexes,sysindexkeys ");
		sql.append("WHERE syscolumns.id =  object_id('girl') AND sysobjects.xtype = 'PK' ");		
		sql.append("AND sysobjects.parent_obj = syscolumns.id ");
		sql.append("AND sysindexes.id = syscolumns.id ");
		sql.append("AND sysobjects.name = sysindexes.name AND sysindexkeys.id = syscolumns.id ");
		sql.append("AND sysindexkeys.indid = sysindexes.indid ");
		sql.append("AND syscolumns.colid = sysindexkeys.colid ");
		LogUtil.log(sql.toString());

		List<Map<String, Object>> result = DBUtil.executeQuery(sql.toString());
		if ((result == null) || (result.size() == 0)) {
			LogUtil.log("all is empty ");
			result = DBUtil.executeQuery(" select 'PID' as column_name ");
			LogUtil.log(" select 'PID' as column_name " + result.size());
		}

		LogUtil.log("id=" + result);
		return result;
	}

	/**
	 * 
	 * 功能描述：查询所有列
	 *
	 * @param table
	 * @return {column_name,nullable,data_type,data_length,scale,column_comment}
	 * @throws SQLException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月19日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Override
	public List<Map<String, Object>> queryAllColumns(String table) throws SQLException {

		StringBuffer sql = new StringBuffer();

		/*
		sql.append(
				" SELECT f.* FROM  (  SELECT t.ORDINAL_POSITION as ID, t.COLUMN_NAME as column_name, left(t.IS_NULLABLE,1) as nullable, t.DATA_TYPE as data_type, t.CHARACTER_MAXIMUM_LENGTH as data_length ");
		sql.append(
				" ,t.NUMERIC_SCALE as scale, t.COLUMN_COMMENT as column_comment FROM INFORMATION_SCHEMA.COLUMNS as t ");
		sql.append("WHERE table_name = '" + table + "' and t.TABLE_SCHEMA = '" + this.schema + "' ) f");		
		*/

		sql.append("SELECT col.name column_name ,col.isnullable nullable ,CONVERT(NVARCHAR(MAX), ty.name) data_type ,col.length data_length ,col.xscale scale ,CONVERT(NVARCHAR(MAX), g.value) column_comment ");
		sql.append("FROM sysobjects obj ");
		sql.append("LEFT JOIN syscolumns col ON obj.id = col.id ");
		sql.append("LEFT JOIN systypes ty ON col.xtype = ty.xusertype ");
		sql.append("LEFT JOIN sys.extended_properties g ON col.id = g.major_id AND col.colid = g.minor_id ");
		sql.append("WHERE   obj.xtype = 'U'AND obj.name = '" + table + "' ");
		LogUtil.log(sql.toString());
		return DBUtil.executeQuery(sql.toString());
	}

	public MysqlDatabase(String url, String username, String password) {
		super(url, username, password);
	}

	public MysqlDatabase() {
		super();
	}

}