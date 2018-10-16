package com.centa.agency.core.dao.base;

import java.io.Serializable;
import java.util.List;

import org.apache.ibatis.annotations.Delete;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Select;
import org.apache.ibatis.annotations.Update;

import org.apache.ibatis.annotations.Options;

import com.misterfat.springboot.starter.mybatis.core.BaseRepository;
import com.misterfat.springboot.starter.mybatis.core.QueryCondition;
import com.centa.agency.core.entity.Girl;

/**
 * 
 *  说明：${tableModel.comment}对象的基础数据访问类（自动生成）
 * 
 * @author 
 * 
 * @version 1.0
 * 
 * @since 2017年09月04日
 */
public interface GirlBaseDao extends BaseRepository<Girl> {

	
		
	/**
	 * 
	 * 功能描述：保存
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Insert({ "insert into girl ( id,age,cup_size)  values (#{id,jdbcType=INTEGER},#{age,jdbcType=INTEGER},#{cupSize,jdbcType=VARCHAR})" })
	@Override
		@Options(useGeneratedKeys = true, keyProperty = "id")
		public int insert(Girl girl);

	/**
	 * 
	 * 功能描述：选择字段保存
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Insert({
			"<script>",
			" insert into girl <trim prefix=\"(\" suffix=\")\" suffixOverrides=\",\" > <if test=\"id != null\" > id, </if> ","<if test=\"age != null\" > age, </if> ","<if test=\"cupSize != null\" > cup_size, </if> "," </trim>  <trim prefix=\"values (\" suffix=\")\" suffixOverrides=\",\" >  <if test=\"id != null\" > #{id,jdbcType=INTEGER}, </if>"," <if test=\"age != null\" > #{age,jdbcType=INTEGER}, </if>"," <if test=\"cupSize != null\" > #{cupSize,jdbcType=VARCHAR}, </if>"," </trim>",
			"</script>" })
	@Override
		@Options(useGeneratedKeys = true, keyProperty = "id")
		public int insertSelective(Girl girl);


	 	/**
	 * 
	 * 功能描述：根据ID删除
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Delete({ "delete from girl where id = #{id,jdbcType=INTEGER}" })
	@Override
	public int deleteById(Serializable id);

	

	/**
	 * 
	 * 功能描述：根据ID数组批量删除
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Delete({
			"<script>",
			"delete from girl where id in <foreach  item=\"id\"  collection=\"array\" open=\"(\" separator=\",\" close=\")\" > #{id} </foreach>",
			"</script>" })
	@Override
	public int batchDelete(Serializable... ids);

		
	/**
	 * 
	 * 功能描述：更新
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Update({ "update girl set id= #{id,jdbcType=INTEGER},age= #{age,jdbcType=INTEGER},cup_size= #{cupSize,jdbcType=VARCHAR} where id = #{id,jdbcType=INTEGER} " })
	@Override
	public int update(Girl girl);

	/**
	 * 
	 * 功能描述：选择字段更新
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Update({
			"<script>",
			"update girl <set > <if test=\"id != null\" > id = #{id,jdbcType=INTEGER}, </if> ","<if test=\"age != null\" > age = #{age,jdbcType=INTEGER}, </if> ","<if test=\"cupSize != null\" > cup_size = #{cupSize,jdbcType=VARCHAR}, </if> "," </set> where id = #{id,jdbcType=INTEGER}",
			"</script>" })
	@Override
	public int updateSelective(Girl girl);
	
	
	/**
	 * 
	 * 功能描述：查询所有
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Select({ "select * from girl" })
	@Override
	public List<Girl> findAll();

	/**
	 * 
	 * 功能描述：查询总数
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	 	@Select({ "select count(id) from girl" })
		@Override
	public int findTotalCount();


	 	 
	/**
	 * 
	 * 功能描述：根据ID查询
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Select({ "select * from girl where id = #{id,jdbcType=INTEGER}" })
	@Override
	public Girl findById(Serializable id);

	
	/**
	 * 
	 * 功能描述：根据查询对象查询
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@Select({
			"<script>",
			"select * from girl <where> 1 = 1 <if test=\"id != null\" > and id = #{id,jdbcType=INTEGER} </if>","<if test=\"idIn != null\" > and id in <foreach  item=\"item\"  collection=\"idIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"idNotIn != null\" > and id not in <foreach  item=\"item\"  collection=\"idNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"idNot != null\" > and id != #{idNot,jdbcType=INTEGER} </if>","<if test=\"idGreaterThan != null\" > and id <![CDATA[>]]>  #{idGreaterThan,jdbcType=INTEGER} </if>","<if test=\"idLessThan != null\" > and id <![CDATA[<]]>  #{idLessThan,jdbcType=INTEGER} </if>","<if test=\"idGreaterEqual != null\" > and id <![CDATA[>=]]>  #{idGreaterEqual,jdbcType=INTEGER} </if>","<if test=\"idLessEqual != null\" > and id <![CDATA[<=]]>  #{idLessEqual,jdbcType=INTEGER} </if>","<if test=\"idIsNull != null\" > and id is null </if>","<if test=\"idIsNotNull != null\" > and id is not null </if>","<if test=\"idLike != null\" > and id like CONCAT('%', #{idLike,jdbcType=INTEGER},'%') </if>","<if test=\"idNotLike != null\" > and id not like CONCAT('%', #{idNotLike,jdbcType=INTEGER},'%') </if>","<if test=\"idStartWith != null\" > and id like CONCAT( #{idStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"idNotStartWith != null\" > and id not like CONCAT( #{idNotStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"idEndWith != null\" > and id like CONCAT('%',  #{idEndWith,jdbcType=INTEGER}) </if>","<if test=\"idNotEndWith != null\" > and id not like CONCAT( '%', #{idNotEndWith,jdbcType=INTEGER}) </if>","<if test=\"idOr != null\" > or id = #{idOr,jdbcType=INTEGER} </if>","<if test=\"idOrIn != null\" > or id in <foreach  item=\"item\"  collection=\"idOrIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"idOrNotIn != null\" > or id  not in <foreach  item=\"item\"  collection=\"idOrNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"idOrNot != null\" > or id != #{idOrNot,jdbcType=INTEGER} </if>","<if test=\"idOrGreaterThan != null\" > or id <![CDATA[>]]>  #{idOrGreaterThan,jdbcType=INTEGER} </if>","<if test=\"idOrLessThan != null\" > or id <![CDATA[<]]>  #{idOrLessThan,jdbcType=INTEGER} </if>","<if test=\"idOrGreaterEqual != null\" > or id <![CDATA[>=]]>  #{idOrGreaterEqual,jdbcType=INTEGER} </if>","<if test=\"idOrLessEqual != null\" > or id <![CDATA[<=]]>  #{idOrLessEqual,jdbcType=INTEGER} </if>","<if test=\"idOrIsNull != null\" > or id is null </if>","<if test=\"idOrIsNotNull != null\" > or id is not null </if>","<if test=\"idOrLike != null\" > or id like CONCAT('%', #{idOrLike,jdbcType=INTEGER},'%') </if>","<if test=\"idOrNotLike != null\" > or id not like CONCAT('%', #{idOrNotLike,jdbcType=INTEGER},'%') </if>","<if test=\"idOrStartWith != null\" > or id like CONCAT( #{idOrStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"idOrNotStartWith != null\" > or id not like CONCAT( #{idOrNotStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"idOrEndWith != null\" > or id like CONCAT('%',  #{idOrEndWith,jdbcType=INTEGER}) </if>","<if test=\"idOrNotEndWith != null\" > or id not like CONCAT( '%', #{idOrNotEndWith,jdbcType=INTEGER}) </if><if test=\"age != null\" > and age = #{age,jdbcType=INTEGER} </if>","<if test=\"ageIn != null\" > and age in <foreach  item=\"item\"  collection=\"ageIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"ageNotIn != null\" > and age not in <foreach  item=\"item\"  collection=\"ageNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"ageNot != null\" > and age != #{ageNot,jdbcType=INTEGER} </if>","<if test=\"ageGreaterThan != null\" > and age <![CDATA[>]]>  #{ageGreaterThan,jdbcType=INTEGER} </if>","<if test=\"ageLessThan != null\" > and age <![CDATA[<]]>  #{ageLessThan,jdbcType=INTEGER} </if>","<if test=\"ageGreaterEqual != null\" > and age <![CDATA[>=]]>  #{ageGreaterEqual,jdbcType=INTEGER} </if>","<if test=\"ageLessEqual != null\" > and age <![CDATA[<=]]>  #{ageLessEqual,jdbcType=INTEGER} </if>","<if test=\"ageIsNull != null\" > and age is null </if>","<if test=\"ageIsNotNull != null\" > and age is not null </if>","<if test=\"ageLike != null\" > and age like CONCAT('%', #{ageLike,jdbcType=INTEGER},'%') </if>","<if test=\"ageNotLike != null\" > and age not like CONCAT('%', #{ageNotLike,jdbcType=INTEGER},'%') </if>","<if test=\"ageStartWith != null\" > and age like CONCAT( #{ageStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"ageNotStartWith != null\" > and age not like CONCAT( #{ageNotStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"ageEndWith != null\" > and age like CONCAT('%',  #{ageEndWith,jdbcType=INTEGER}) </if>","<if test=\"ageNotEndWith != null\" > and age not like CONCAT( '%', #{ageNotEndWith,jdbcType=INTEGER}) </if>","<if test=\"ageOr != null\" > or age = #{ageOr,jdbcType=INTEGER} </if>","<if test=\"ageOrIn != null\" > or age in <foreach  item=\"item\"  collection=\"ageOrIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"ageOrNotIn != null\" > or age  not in <foreach  item=\"item\"  collection=\"ageOrNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"ageOrNot != null\" > or age != #{ageOrNot,jdbcType=INTEGER} </if>","<if test=\"ageOrGreaterThan != null\" > or age <![CDATA[>]]>  #{ageOrGreaterThan,jdbcType=INTEGER} </if>","<if test=\"ageOrLessThan != null\" > or age <![CDATA[<]]>  #{ageOrLessThan,jdbcType=INTEGER} </if>","<if test=\"ageOrGreaterEqual != null\" > or age <![CDATA[>=]]>  #{ageOrGreaterEqual,jdbcType=INTEGER} </if>","<if test=\"ageOrLessEqual != null\" > or age <![CDATA[<=]]>  #{ageOrLessEqual,jdbcType=INTEGER} </if>","<if test=\"ageOrIsNull != null\" > or age is null </if>","<if test=\"ageOrIsNotNull != null\" > or age is not null </if>","<if test=\"ageOrLike != null\" > or age like CONCAT('%', #{ageOrLike,jdbcType=INTEGER},'%') </if>","<if test=\"ageOrNotLike != null\" > or age not like CONCAT('%', #{ageOrNotLike,jdbcType=INTEGER},'%') </if>","<if test=\"ageOrStartWith != null\" > or age like CONCAT( #{ageOrStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"ageOrNotStartWith != null\" > or age not like CONCAT( #{ageOrNotStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"ageOrEndWith != null\" > or age like CONCAT('%',  #{ageOrEndWith,jdbcType=INTEGER}) </if>","<if test=\"ageOrNotEndWith != null\" > or age not like CONCAT( '%', #{ageOrNotEndWith,jdbcType=INTEGER}) </if><if test=\"cupSize != null\" > and cup_size = #{cupSize,jdbcType=VARCHAR} </if>","<if test=\"cupSizeIn != null\" > and cup_size in <foreach  item=\"item\"  collection=\"cupSizeIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"cupSizeNotIn != null\" > and cup_size not in <foreach  item=\"item\"  collection=\"cupSizeNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"cupSizeNot != null\" > and cup_size != #{cupSizeNot,jdbcType=VARCHAR} </if>","<if test=\"cupSizeGreaterThan != null\" > and cup_size <![CDATA[>]]>  #{cupSizeGreaterThan,jdbcType=VARCHAR} </if>","<if test=\"cupSizeLessThan != null\" > and cup_size <![CDATA[<]]>  #{cupSizeLessThan,jdbcType=VARCHAR} </if>","<if test=\"cupSizeGreaterEqual != null\" > and cup_size <![CDATA[>=]]>  #{cupSizeGreaterEqual,jdbcType=VARCHAR} </if>","<if test=\"cupSizeLessEqual != null\" > and cup_size <![CDATA[<=]]>  #{cupSizeLessEqual,jdbcType=VARCHAR} </if>","<if test=\"cupSizeIsNull != null\" > and cup_size is null </if>","<if test=\"cupSizeIsNotNull != null\" > and cup_size is not null </if>","<if test=\"cupSizeLike != null\" > and cup_size like CONCAT('%', #{cupSizeLike,jdbcType=VARCHAR},'%') </if>","<if test=\"cupSizeNotLike != null\" > and cup_size not like CONCAT('%', #{cupSizeNotLike,jdbcType=VARCHAR},'%') </if>","<if test=\"cupSizeStartWith != null\" > and cup_size like CONCAT( #{cupSizeStartWith,jdbcType=VARCHAR},'%')  </if>","<if test=\"cupSizeNotStartWith != null\" > and cup_size not like CONCAT( #{cupSizeNotStartWith,jdbcType=VARCHAR},'%')  </if>","<if test=\"cupSizeEndWith != null\" > and cup_size like CONCAT('%',  #{cupSizeEndWith,jdbcType=VARCHAR}) </if>","<if test=\"cupSizeNotEndWith != null\" > and cup_size not like CONCAT( '%', #{cupSizeNotEndWith,jdbcType=VARCHAR}) </if>","<if test=\"cupSizeOr != null\" > or cup_size = #{cupSizeOr,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrIn != null\" > or cup_size in <foreach  item=\"item\"  collection=\"cupSizeOrIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"cupSizeOrNotIn != null\" > or cup_size  not in <foreach  item=\"item\"  collection=\"cupSizeOrNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"cupSizeOrNot != null\" > or cup_size != #{cupSizeOrNot,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrGreaterThan != null\" > or cup_size <![CDATA[>]]>  #{cupSizeOrGreaterThan,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrLessThan != null\" > or cup_size <![CDATA[<]]>  #{cupSizeOrLessThan,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrGreaterEqual != null\" > or cup_size <![CDATA[>=]]>  #{cupSizeOrGreaterEqual,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrLessEqual != null\" > or cup_size <![CDATA[<=]]>  #{cupSizeOrLessEqual,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrIsNull != null\" > or cup_size is null </if>","<if test=\"cupSizeOrIsNotNull != null\" > or cup_size is not null </if>","<if test=\"cupSizeOrLike != null\" > or cup_size like CONCAT('%', #{cupSizeOrLike,jdbcType=VARCHAR},'%') </if>","<if test=\"cupSizeOrNotLike != null\" > or cup_size not like CONCAT('%', #{cupSizeOrNotLike,jdbcType=VARCHAR},'%') </if>","<if test=\"cupSizeOrStartWith != null\" > or cup_size like CONCAT( #{cupSizeOrStartWith,jdbcType=VARCHAR},'%')  </if>","<if test=\"cupSizeOrNotStartWith != null\" > or cup_size not like CONCAT( #{cupSizeOrNotStartWith,jdbcType=VARCHAR},'%')  </if>","<if test=\"cupSizeOrEndWith != null\" > or cup_size like CONCAT('%',  #{cupSizeOrEndWith,jdbcType=VARCHAR}) </if>","<if test=\"cupSizeOrNotEndWith != null\" > or cup_size not like CONCAT( '%', #{cupSizeOrNotEndWith,jdbcType=VARCHAR}) </if> </where>",
			"</script>" })
	@Override
	public List<Girl> findList(QueryCondition query);

	/**
	 * 
	 * 功能描述：根据查询对象查询记录数
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2017年09月04日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
    	@Select({
			"<script>",
			"select count(id) from girl <where> 1 = 1 <if test=\"id != null\" > and id = #{id,jdbcType=INTEGER} </if>","<if test=\"idIn != null\" > and id in <foreach  item=\"item\"  collection=\"idIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"idNotIn != null\" > and id not in <foreach  item=\"item\"  collection=\"idNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"idNot != null\" > and id != #{idNot,jdbcType=INTEGER} </if>","<if test=\"idGreaterThan != null\" > and id <![CDATA[>]]>  #{idGreaterThan,jdbcType=INTEGER} </if>","<if test=\"idLessThan != null\" > and id <![CDATA[<]]>  #{idLessThan,jdbcType=INTEGER} </if>","<if test=\"idGreaterEqual != null\" > and id <![CDATA[>=]]>  #{idGreaterEqual,jdbcType=INTEGER} </if>","<if test=\"idLessEqual != null\" > and id <![CDATA[<=]]>  #{idLessEqual,jdbcType=INTEGER} </if>","<if test=\"idIsNull != null\" > and id is null </if>","<if test=\"idIsNotNull != null\" > and id is not null </if>","<if test=\"idLike != null\" > and id like CONCAT('%', #{idLike,jdbcType=INTEGER},'%') </if>","<if test=\"idNotLike != null\" > and id not like CONCAT('%', #{idNotLike,jdbcType=INTEGER},'%') </if>","<if test=\"idStartWith != null\" > and id like CONCAT( #{idStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"idNotStartWith != null\" > and id not like CONCAT( #{idNotStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"idEndWith != null\" > and id like CONCAT('%',  #{idEndWith,jdbcType=INTEGER}) </if>","<if test=\"idNotEndWith != null\" > and id not like CONCAT( '%', #{idNotEndWith,jdbcType=INTEGER}) </if>","<if test=\"idOr != null\" > or id = #{idOr,jdbcType=INTEGER} </if>","<if test=\"idOrIn != null\" > or id in <foreach  item=\"item\"  collection=\"idOrIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"idOrNotIn != null\" > or id  not in <foreach  item=\"item\"  collection=\"idOrNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"idOrNot != null\" > or id != #{idOrNot,jdbcType=INTEGER} </if>","<if test=\"idOrGreaterThan != null\" > or id <![CDATA[>]]>  #{idOrGreaterThan,jdbcType=INTEGER} </if>","<if test=\"idOrLessThan != null\" > or id <![CDATA[<]]>  #{idOrLessThan,jdbcType=INTEGER} </if>","<if test=\"idOrGreaterEqual != null\" > or id <![CDATA[>=]]>  #{idOrGreaterEqual,jdbcType=INTEGER} </if>","<if test=\"idOrLessEqual != null\" > or id <![CDATA[<=]]>  #{idOrLessEqual,jdbcType=INTEGER} </if>","<if test=\"idOrIsNull != null\" > or id is null </if>","<if test=\"idOrIsNotNull != null\" > or id is not null </if>","<if test=\"idOrLike != null\" > or id like CONCAT('%', #{idOrLike,jdbcType=INTEGER},'%') </if>","<if test=\"idOrNotLike != null\" > or id not like CONCAT('%', #{idOrNotLike,jdbcType=INTEGER},'%') </if>","<if test=\"idOrStartWith != null\" > or id like CONCAT( #{idOrStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"idOrNotStartWith != null\" > or id not like CONCAT( #{idOrNotStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"idOrEndWith != null\" > or id like CONCAT('%',  #{idOrEndWith,jdbcType=INTEGER}) </if>","<if test=\"idOrNotEndWith != null\" > or id not like CONCAT( '%', #{idOrNotEndWith,jdbcType=INTEGER}) </if><if test=\"age != null\" > and age = #{age,jdbcType=INTEGER} </if>","<if test=\"ageIn != null\" > and age in <foreach  item=\"item\"  collection=\"ageIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"ageNotIn != null\" > and age not in <foreach  item=\"item\"  collection=\"ageNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"ageNot != null\" > and age != #{ageNot,jdbcType=INTEGER} </if>","<if test=\"ageGreaterThan != null\" > and age <![CDATA[>]]>  #{ageGreaterThan,jdbcType=INTEGER} </if>","<if test=\"ageLessThan != null\" > and age <![CDATA[<]]>  #{ageLessThan,jdbcType=INTEGER} </if>","<if test=\"ageGreaterEqual != null\" > and age <![CDATA[>=]]>  #{ageGreaterEqual,jdbcType=INTEGER} </if>","<if test=\"ageLessEqual != null\" > and age <![CDATA[<=]]>  #{ageLessEqual,jdbcType=INTEGER} </if>","<if test=\"ageIsNull != null\" > and age is null </if>","<if test=\"ageIsNotNull != null\" > and age is not null </if>","<if test=\"ageLike != null\" > and age like CONCAT('%', #{ageLike,jdbcType=INTEGER},'%') </if>","<if test=\"ageNotLike != null\" > and age not like CONCAT('%', #{ageNotLike,jdbcType=INTEGER},'%') </if>","<if test=\"ageStartWith != null\" > and age like CONCAT( #{ageStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"ageNotStartWith != null\" > and age not like CONCAT( #{ageNotStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"ageEndWith != null\" > and age like CONCAT('%',  #{ageEndWith,jdbcType=INTEGER}) </if>","<if test=\"ageNotEndWith != null\" > and age not like CONCAT( '%', #{ageNotEndWith,jdbcType=INTEGER}) </if>","<if test=\"ageOr != null\" > or age = #{ageOr,jdbcType=INTEGER} </if>","<if test=\"ageOrIn != null\" > or age in <foreach  item=\"item\"  collection=\"ageOrIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"ageOrNotIn != null\" > or age  not in <foreach  item=\"item\"  collection=\"ageOrNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"ageOrNot != null\" > or age != #{ageOrNot,jdbcType=INTEGER} </if>","<if test=\"ageOrGreaterThan != null\" > or age <![CDATA[>]]>  #{ageOrGreaterThan,jdbcType=INTEGER} </if>","<if test=\"ageOrLessThan != null\" > or age <![CDATA[<]]>  #{ageOrLessThan,jdbcType=INTEGER} </if>","<if test=\"ageOrGreaterEqual != null\" > or age <![CDATA[>=]]>  #{ageOrGreaterEqual,jdbcType=INTEGER} </if>","<if test=\"ageOrLessEqual != null\" > or age <![CDATA[<=]]>  #{ageOrLessEqual,jdbcType=INTEGER} </if>","<if test=\"ageOrIsNull != null\" > or age is null </if>","<if test=\"ageOrIsNotNull != null\" > or age is not null </if>","<if test=\"ageOrLike != null\" > or age like CONCAT('%', #{ageOrLike,jdbcType=INTEGER},'%') </if>","<if test=\"ageOrNotLike != null\" > or age not like CONCAT('%', #{ageOrNotLike,jdbcType=INTEGER},'%') </if>","<if test=\"ageOrStartWith != null\" > or age like CONCAT( #{ageOrStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"ageOrNotStartWith != null\" > or age not like CONCAT( #{ageOrNotStartWith,jdbcType=INTEGER},'%')  </if>","<if test=\"ageOrEndWith != null\" > or age like CONCAT('%',  #{ageOrEndWith,jdbcType=INTEGER}) </if>","<if test=\"ageOrNotEndWith != null\" > or age not like CONCAT( '%', #{ageOrNotEndWith,jdbcType=INTEGER}) </if><if test=\"cupSize != null\" > and cup_size = #{cupSize,jdbcType=VARCHAR} </if>","<if test=\"cupSizeIn != null\" > and cup_size in <foreach  item=\"item\"  collection=\"cupSizeIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"cupSizeNotIn != null\" > and cup_size not in <foreach  item=\"item\"  collection=\"cupSizeNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"cupSizeNot != null\" > and cup_size != #{cupSizeNot,jdbcType=VARCHAR} </if>","<if test=\"cupSizeGreaterThan != null\" > and cup_size <![CDATA[>]]>  #{cupSizeGreaterThan,jdbcType=VARCHAR} </if>","<if test=\"cupSizeLessThan != null\" > and cup_size <![CDATA[<]]>  #{cupSizeLessThan,jdbcType=VARCHAR} </if>","<if test=\"cupSizeGreaterEqual != null\" > and cup_size <![CDATA[>=]]>  #{cupSizeGreaterEqual,jdbcType=VARCHAR} </if>","<if test=\"cupSizeLessEqual != null\" > and cup_size <![CDATA[<=]]>  #{cupSizeLessEqual,jdbcType=VARCHAR} </if>","<if test=\"cupSizeIsNull != null\" > and cup_size is null </if>","<if test=\"cupSizeIsNotNull != null\" > and cup_size is not null </if>","<if test=\"cupSizeLike != null\" > and cup_size like CONCAT('%', #{cupSizeLike,jdbcType=VARCHAR},'%') </if>","<if test=\"cupSizeNotLike != null\" > and cup_size not like CONCAT('%', #{cupSizeNotLike,jdbcType=VARCHAR},'%') </if>","<if test=\"cupSizeStartWith != null\" > and cup_size like CONCAT( #{cupSizeStartWith,jdbcType=VARCHAR},'%')  </if>","<if test=\"cupSizeNotStartWith != null\" > and cup_size not like CONCAT( #{cupSizeNotStartWith,jdbcType=VARCHAR},'%')  </if>","<if test=\"cupSizeEndWith != null\" > and cup_size like CONCAT('%',  #{cupSizeEndWith,jdbcType=VARCHAR}) </if>","<if test=\"cupSizeNotEndWith != null\" > and cup_size not like CONCAT( '%', #{cupSizeNotEndWith,jdbcType=VARCHAR}) </if>","<if test=\"cupSizeOr != null\" > or cup_size = #{cupSizeOr,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrIn != null\" > or cup_size in <foreach  item=\"item\"  collection=\"cupSizeOrIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"cupSizeOrNotIn != null\" > or cup_size  not in <foreach  item=\"item\"  collection=\"cupSizeOrNotIn\" open=\"(\" separator=\",\" close=\")\" > #{item} </foreach> </if>","<if test=\"cupSizeOrNot != null\" > or cup_size != #{cupSizeOrNot,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrGreaterThan != null\" > or cup_size <![CDATA[>]]>  #{cupSizeOrGreaterThan,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrLessThan != null\" > or cup_size <![CDATA[<]]>  #{cupSizeOrLessThan,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrGreaterEqual != null\" > or cup_size <![CDATA[>=]]>  #{cupSizeOrGreaterEqual,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrLessEqual != null\" > or cup_size <![CDATA[<=]]>  #{cupSizeOrLessEqual,jdbcType=VARCHAR} </if>","<if test=\"cupSizeOrIsNull != null\" > or cup_size is null </if>","<if test=\"cupSizeOrIsNotNull != null\" > or cup_size is not null </if>","<if test=\"cupSizeOrLike != null\" > or cup_size like CONCAT('%', #{cupSizeOrLike,jdbcType=VARCHAR},'%') </if>","<if test=\"cupSizeOrNotLike != null\" > or cup_size not like CONCAT('%', #{cupSizeOrNotLike,jdbcType=VARCHAR},'%') </if>","<if test=\"cupSizeOrStartWith != null\" > or cup_size like CONCAT( #{cupSizeOrStartWith,jdbcType=VARCHAR},'%')  </if>","<if test=\"cupSizeOrNotStartWith != null\" > or cup_size not like CONCAT( #{cupSizeOrNotStartWith,jdbcType=VARCHAR},'%')  </if>","<if test=\"cupSizeOrEndWith != null\" > or cup_size like CONCAT('%',  #{cupSizeOrEndWith,jdbcType=VARCHAR}) </if>","<if test=\"cupSizeOrNotEndWith != null\" > or cup_size not like CONCAT( '%', #{cupSizeOrNotEndWith,jdbcType=VARCHAR}) </if> </where>",
			"</script>" })
		@Override
	public int findCount(QueryCondition query);


}

