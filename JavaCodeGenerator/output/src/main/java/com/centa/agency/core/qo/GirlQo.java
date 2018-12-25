package com.centa.agency.core.qo;





import com.misterfat.springboot.starter.mybatis.core.PageQueryCondition;


/**
 * 
 * QO设置属性的顺序不代表生成SQL的顺序,
 * SQL生成规则请参考 GirlBaseDao,
 * where条件中带OR复杂查询不要使用QO
 *
 * @author 
 *
 * @version 1.0
 *
 * @since 2017年09月04日
 */
public class GirlQo extends PageQueryCondition {



 							private Integer id; //${property.comment}等于
	
 							private Integer[] idIn; //${property.comment}在...之中
	
 							private Integer[] idNotIn; //${property.comment}不在...之中

 							private Integer idNot; //${property.comment}不等于

 							private Integer idGreaterThan; //${property.comment}大于

 							private Integer idLessThan; //${property.comment}小于

 							private Integer idGreaterEqual; //${property.comment}大于等于

 							private Integer idLessEqual; //${property.comment}小于等于
	
	private String idIsNull; //${property.comment}等于Null
	
	private String idIsNotNull; //${property.comment}不等于Null
	
	private String idLike; //${property.comment}包含

	private String idNotLike; //${property.comment}不包含

	private String idStartWith; //${property.comment}以...开始

	private String idNotStartWith; //${property.comment}不以...开始

	private String idEndWith; //${property.comment}以...结束 

	private String idNotEndWith; //${property.comment}不以...结束 
	
	
	
	
	
	
	
	
	
	
	
	
							private Integer idOr; //或者${property.comment}等于
	
							private Integer[] idOrIn; //或者${property.comment}在...之中
	
							private Integer[] idOrNotIn; //或者${property.comment}不在...之中

 							private Integer idOrNot; //或者${property.comment}不等于

 							private Integer idOrGreaterThan; //或者${property.comment}大于

 							private Integer idOrLessThan; //或者${property.comment}小于

 							private Integer idOrGreaterEqual; //或者${property.comment}大于等于

 							private Integer idOrLessEqual; //或者${property.comment}小于等于
	
	private String idOrIsNull; //或者${property.comment}等于Null
	
	private String idOrIsNotNull; //或者${property.comment}不等于Null
	
	private String idOrLike; //或者${property.comment}包含

	private String idOrNotLike; //或者${property.comment}不包含

	private String idOrStartWith; //或者${property.comment}以...开始

	private String idOrNotStartWith; //或者${property.comment}不以...开始

	private String idOrEndWith; //或者${property.comment}以...结束 

	private String idOrNotEndWith; //或者${property.comment}不以...结束 
	



 							private Integer age; //年龄等于
	
 							private Integer[] ageIn; //年龄在...之中
	
 							private Integer[] ageNotIn; //年龄不在...之中

 							private Integer ageNot; //年龄不等于

 							private Integer ageGreaterThan; //年龄大于

 							private Integer ageLessThan; //年龄小于

 							private Integer ageGreaterEqual; //年龄大于等于

 							private Integer ageLessEqual; //年龄小于等于
	
	private String ageIsNull; //年龄等于Null
	
	private String ageIsNotNull; //年龄不等于Null
	
	private String ageLike; //年龄包含

	private String ageNotLike; //年龄不包含

	private String ageStartWith; //年龄以...开始

	private String ageNotStartWith; //年龄不以...开始

	private String ageEndWith; //年龄以...结束 

	private String ageNotEndWith; //年龄不以...结束 
	
	
	
	
	
	
	
	
	
	
	
	
							private Integer ageOr; //或者年龄等于
	
							private Integer[] ageOrIn; //或者年龄在...之中
	
							private Integer[] ageOrNotIn; //或者年龄不在...之中

 							private Integer ageOrNot; //或者年龄不等于

 							private Integer ageOrGreaterThan; //或者年龄大于

 							private Integer ageOrLessThan; //或者年龄小于

 							private Integer ageOrGreaterEqual; //或者年龄大于等于

 							private Integer ageOrLessEqual; //或者年龄小于等于
	
	private String ageOrIsNull; //或者年龄等于Null
	
	private String ageOrIsNotNull; //或者年龄不等于Null
	
	private String ageOrLike; //或者年龄包含

	private String ageOrNotLike; //或者年龄不包含

	private String ageOrStartWith; //或者年龄以...开始

	private String ageOrNotStartWith; //或者年龄不以...开始

	private String ageOrEndWith; //或者年龄以...结束 

	private String ageOrNotEndWith; //或者年龄不以...结束 
	



 							private String cupSize; //size等于
	
 							private String[] cupSizeIn; //size在...之中
	
 							private String[] cupSizeNotIn; //size不在...之中

 							private String cupSizeNot; //size不等于

 							private String cupSizeGreaterThan; //size大于

 							private String cupSizeLessThan; //size小于

 							private String cupSizeGreaterEqual; //size大于等于

 							private String cupSizeLessEqual; //size小于等于
	
	private String cupSizeIsNull; //size等于Null
	
	private String cupSizeIsNotNull; //size不等于Null
	
	private String cupSizeLike; //size包含

	private String cupSizeNotLike; //size不包含

	private String cupSizeStartWith; //size以...开始

	private String cupSizeNotStartWith; //size不以...开始

	private String cupSizeEndWith; //size以...结束 

	private String cupSizeNotEndWith; //size不以...结束 
	
	
	
	
	
	
	
	
	
	
	
	
							private String cupSizeOr; //或者size等于
	
							private String[] cupSizeOrIn; //或者size在...之中
	
							private String[] cupSizeOrNotIn; //或者size不在...之中

 							private String cupSizeOrNot; //或者size不等于

 							private String cupSizeOrGreaterThan; //或者size大于

 							private String cupSizeOrLessThan; //或者size小于

 							private String cupSizeOrGreaterEqual; //或者size大于等于

 							private String cupSizeOrLessEqual; //或者size小于等于
	
	private String cupSizeOrIsNull; //或者size等于Null
	
	private String cupSizeOrIsNotNull; //或者size不等于Null
	
	private String cupSizeOrLike; //或者size包含

	private String cupSizeOrNotLike; //或者size不包含

	private String cupSizeOrStartWith; //或者size以...开始

	private String cupSizeOrNotStartWith; //或者size不以...开始

	private String cupSizeOrEndWith; //或者size以...结束 

	private String cupSizeOrNotEndWith; //或者size不以...结束 
	




/** 以下为get,set方法 */
    
   						        	
    	public Integer getId() {
	        return this.id;
        }
        
        public void setId(Integer id) {
        	this.id = id;
        }
    
   						        	
    	public Integer[] getIdIn() {
	        return this.idIn;
        }
        
        public void setIdIn(Integer... idIn) {
        	this.idIn = idIn;
        }
    
   						        	
    	public Integer[] getIdNotIn() {
	        return this.idNotIn;
        }
        
        public void setIdNotIn(Integer... idNotIn) {
        	this.idNotIn = idNotIn;
        }
        
        				        public Integer getIdNot() {
			return idNot;
		}
	
		public void setIdNot(Integer idNot) {
			this.idNot = idNot;
		}
	
								public Integer getIdGreaterThan() {
			return idGreaterThan;
		}
	
		public void setIdGreaterThan(Integer idGreaterThan) {
			this.idGreaterThan = idGreaterThan;
		}
		
								public Integer getIdLessThan() {
			return idLessThan;
		}
	
		public void setIdLessThan(Integer idLessThan) {
			this.idLessThan = idLessThan;
		}
	
								public Integer getIdGreaterEqual() {
			return idGreaterEqual;
		}
	
		public void setIdGreaterEqual(Integer idGreaterEqual) {
			this.idGreaterEqual = idGreaterEqual;
		}
	
								public Integer getIdLessEqual() {
			return idLessEqual;
		}
	
		public void setIdLessEqual(Integer idLessEqual) {
			this.idLessEqual = idLessEqual;
		}
	
		public String getIdIsNull() {
			return idIsNull;
		}
	
		public void setIdIsNull() {
			this.idIsNull = NULL_VALUE;
		}
	
		public String getIdIsNotNull() {
			return idIsNotNull;
		}
	
		public void setIdIsNotNull() {
			this.idIsNotNull = NULL_VALUE;
		}
	
		public String getIdLike() {
			return idLike;
		}
	
		public void setIdLike(String idLike) {
			this.idLike = idLike;
		}
	
		public String getIdNotLike() {
			return idNotLike;
		}
	
		public void setIdNotLike(String idNotLike) {
			this.idNotLike = idNotLike;
		}
	
		public String getIdStartWith() {
			return idStartWith;
		}
	
		public void setIdStartWith(String idStartWith) {
			this.idStartWith = idStartWith;
		}
	
		public String getIdNotStartWith() {
			return idNotStartWith;
		}
	
		public void setIdNotStartWith(String idNotStartWith) {
			this.idNotStartWith = idNotStartWith;
		}
	
		public String getIdEndWith() {
			return idEndWith;
		}
	
		public void setIdEndWith(String idEndWith) {
			this.idEndWith = idEndWith;
		}
	
		public String getIdNotEndWith() {
			return idNotEndWith;
		}
	
		public void setIdNotEndWith(String idNotEndWith) {
			this.idNotEndWith = idNotEndWith;
		}
	
	
	
	
	
	
	
	
	
	
	
	
						        	
    	public Integer getIdOr() {
	        return this.idOr;
        }
        
        public void setIdOr(Integer idOr) {
        	this.idOr = idOr;
        }
        
        				        	
    	public Integer[] getIdOrIn() {
	        return this.idOrIn;
        }
        
        public void setIdOrIn(Integer... idOrIn) {
        	this.idOrIn = idOrIn;
        }
        
        				        	
    	public Integer[] getIdOrNotIn() {
	        return this.idOrNotIn;
        }
        
        public void setIdOrNotIn(Integer... idOrNotIn) {
        	this.idOrNotIn = idOrNotIn;
        }
        
        				        public Integer getIdOrNot() {
			return idOrNot;
		}
	
		public void setIdOrNot(Integer idOrNot) {
			this.idOrNot = idOrNot;
		}
	
								public Integer getIdOrGreaterThan() {
			return idOrGreaterThan;
		}
	
		public void setIdOrGreaterThan(Integer idOrGreaterThan) {
			this.idOrGreaterThan = idOrGreaterThan;
		}
		
								public Integer getIdOrLessThan() {
			return idOrLessThan;
		}
	
		public void setIdOrLessThan(Integer idOrLessThan) {
			this.idOrLessThan = idOrLessThan;
		}
	
								public Integer getIdOrGreaterEqual() {
			return idOrGreaterEqual;
		}
	
		public void setIdOrGreaterEqual(Integer idOrGreaterEqual) {
			this.idOrGreaterEqual = idOrGreaterEqual;
		}
	
								public Integer getIdOrLessEqual() {
			return idOrLessEqual;
		}
	
		public void setIdOrLessEqual(Integer idOrLessEqual) {
			this.idOrLessEqual = idOrLessEqual;
		}
	
		public String getIdOrIsNull() {
			return idOrIsNull;
		}
	
		public void setIdOrIsNull() {
			this.idOrIsNull = NULL_VALUE;
		}
	
		public String getIdOrIsNotNull() {
			return idOrIsNotNull;
		}
	
		public void setIdOrIsNotNull() {
			this.idOrIsNotNull = NULL_VALUE;
		}
	
		public String getIdOrLike() {
			return idOrLike;
		}
	
		public void setIdOrLike(String idOrLike) {
			this.idOrLike = idOrLike;
		}
	
		public String getIdOrNotLike() {
			return idOrNotLike;
		}
	
		public void setIdOrNotLike(String idOrNotLike) {
			this.idOrNotLike = idOrNotLike;
		}
	
		public String getIdOrStartWith() {
			return idOrStartWith;
		}
	
		public void setIdOrStartWith(String idOrStartWith) {
			this.idOrStartWith = idOrStartWith;
		}
	
		public String getIdOrNotStartWith() {
			return idOrNotStartWith;
		}
	
		public void setIdOrNotStartWith(String idOrNotStartWith) {
			this.idOrNotStartWith = idOrNotStartWith;
		}
	
		public String getIdOrEndWith() {
			return idOrEndWith;
		}
	
		public void setIdOrEndWith(String idOrEndWith) {
			this.idOrEndWith = idOrEndWith;
		}
	
		public String getIdOrNotEndWith() {
			return idOrNotEndWith;
		}
	
		public void setIdOrNotEndWith(String idOrNotEndWith) {
			this.idOrNotEndWith = idOrNotEndWith;
		}
	
	

    
   						        	
    	public Integer getAge() {
	        return this.age;
        }
        
        public void setAge(Integer age) {
        	this.age = age;
        }
    
   						        	
    	public Integer[] getAgeIn() {
	        return this.ageIn;
        }
        
        public void setAgeIn(Integer... ageIn) {
        	this.ageIn = ageIn;
        }
    
   						        	
    	public Integer[] getAgeNotIn() {
	        return this.ageNotIn;
        }
        
        public void setAgeNotIn(Integer... ageNotIn) {
        	this.ageNotIn = ageNotIn;
        }
        
        				        public Integer getAgeNot() {
			return ageNot;
		}
	
		public void setAgeNot(Integer ageNot) {
			this.ageNot = ageNot;
		}
	
								public Integer getAgeGreaterThan() {
			return ageGreaterThan;
		}
	
		public void setAgeGreaterThan(Integer ageGreaterThan) {
			this.ageGreaterThan = ageGreaterThan;
		}
		
								public Integer getAgeLessThan() {
			return ageLessThan;
		}
	
		public void setAgeLessThan(Integer ageLessThan) {
			this.ageLessThan = ageLessThan;
		}
	
								public Integer getAgeGreaterEqual() {
			return ageGreaterEqual;
		}
	
		public void setAgeGreaterEqual(Integer ageGreaterEqual) {
			this.ageGreaterEqual = ageGreaterEqual;
		}
	
								public Integer getAgeLessEqual() {
			return ageLessEqual;
		}
	
		public void setAgeLessEqual(Integer ageLessEqual) {
			this.ageLessEqual = ageLessEqual;
		}
	
		public String getAgeIsNull() {
			return ageIsNull;
		}
	
		public void setAgeIsNull() {
			this.ageIsNull = NULL_VALUE;
		}
	
		public String getAgeIsNotNull() {
			return ageIsNotNull;
		}
	
		public void setAgeIsNotNull() {
			this.ageIsNotNull = NULL_VALUE;
		}
	
		public String getAgeLike() {
			return ageLike;
		}
	
		public void setAgeLike(String ageLike) {
			this.ageLike = ageLike;
		}
	
		public String getAgeNotLike() {
			return ageNotLike;
		}
	
		public void setAgeNotLike(String ageNotLike) {
			this.ageNotLike = ageNotLike;
		}
	
		public String getAgeStartWith() {
			return ageStartWith;
		}
	
		public void setAgeStartWith(String ageStartWith) {
			this.ageStartWith = ageStartWith;
		}
	
		public String getAgeNotStartWith() {
			return ageNotStartWith;
		}
	
		public void setAgeNotStartWith(String ageNotStartWith) {
			this.ageNotStartWith = ageNotStartWith;
		}
	
		public String getAgeEndWith() {
			return ageEndWith;
		}
	
		public void setAgeEndWith(String ageEndWith) {
			this.ageEndWith = ageEndWith;
		}
	
		public String getAgeNotEndWith() {
			return ageNotEndWith;
		}
	
		public void setAgeNotEndWith(String ageNotEndWith) {
			this.ageNotEndWith = ageNotEndWith;
		}
	
	
	
	
	
	
	
	
	
	
	
	
						        	
    	public Integer getAgeOr() {
	        return this.ageOr;
        }
        
        public void setAgeOr(Integer ageOr) {
        	this.ageOr = ageOr;
        }
        
        				        	
    	public Integer[] getAgeOrIn() {
	        return this.ageOrIn;
        }
        
        public void setAgeOrIn(Integer... ageOrIn) {
        	this.ageOrIn = ageOrIn;
        }
        
        				        	
    	public Integer[] getAgeOrNotIn() {
	        return this.ageOrNotIn;
        }
        
        public void setAgeOrNotIn(Integer... ageOrNotIn) {
        	this.ageOrNotIn = ageOrNotIn;
        }
        
        				        public Integer getAgeOrNot() {
			return ageOrNot;
		}
	
		public void setAgeOrNot(Integer ageOrNot) {
			this.ageOrNot = ageOrNot;
		}
	
								public Integer getAgeOrGreaterThan() {
			return ageOrGreaterThan;
		}
	
		public void setAgeOrGreaterThan(Integer ageOrGreaterThan) {
			this.ageOrGreaterThan = ageOrGreaterThan;
		}
		
								public Integer getAgeOrLessThan() {
			return ageOrLessThan;
		}
	
		public void setAgeOrLessThan(Integer ageOrLessThan) {
			this.ageOrLessThan = ageOrLessThan;
		}
	
								public Integer getAgeOrGreaterEqual() {
			return ageOrGreaterEqual;
		}
	
		public void setAgeOrGreaterEqual(Integer ageOrGreaterEqual) {
			this.ageOrGreaterEqual = ageOrGreaterEqual;
		}
	
								public Integer getAgeOrLessEqual() {
			return ageOrLessEqual;
		}
	
		public void setAgeOrLessEqual(Integer ageOrLessEqual) {
			this.ageOrLessEqual = ageOrLessEqual;
		}
	
		public String getAgeOrIsNull() {
			return ageOrIsNull;
		}
	
		public void setAgeOrIsNull() {
			this.ageOrIsNull = NULL_VALUE;
		}
	
		public String getAgeOrIsNotNull() {
			return ageOrIsNotNull;
		}
	
		public void setAgeOrIsNotNull() {
			this.ageOrIsNotNull = NULL_VALUE;
		}
	
		public String getAgeOrLike() {
			return ageOrLike;
		}
	
		public void setAgeOrLike(String ageOrLike) {
			this.ageOrLike = ageOrLike;
		}
	
		public String getAgeOrNotLike() {
			return ageOrNotLike;
		}
	
		public void setAgeOrNotLike(String ageOrNotLike) {
			this.ageOrNotLike = ageOrNotLike;
		}
	
		public String getAgeOrStartWith() {
			return ageOrStartWith;
		}
	
		public void setAgeOrStartWith(String ageOrStartWith) {
			this.ageOrStartWith = ageOrStartWith;
		}
	
		public String getAgeOrNotStartWith() {
			return ageOrNotStartWith;
		}
	
		public void setAgeOrNotStartWith(String ageOrNotStartWith) {
			this.ageOrNotStartWith = ageOrNotStartWith;
		}
	
		public String getAgeOrEndWith() {
			return ageOrEndWith;
		}
	
		public void setAgeOrEndWith(String ageOrEndWith) {
			this.ageOrEndWith = ageOrEndWith;
		}
	
		public String getAgeOrNotEndWith() {
			return ageOrNotEndWith;
		}
	
		public void setAgeOrNotEndWith(String ageOrNotEndWith) {
			this.ageOrNotEndWith = ageOrNotEndWith;
		}
	
	

    
   						        	
    	public String getCupSize() {
	        return this.cupSize;
        }
        
        public void setCupSize(String cupSize) {
        	this.cupSize = cupSize;
        }
    
   						        	
    	public String[] getCupSizeIn() {
	        return this.cupSizeIn;
        }
        
        public void setCupSizeIn(String... cupSizeIn) {
        	this.cupSizeIn = cupSizeIn;
        }
    
   						        	
    	public String[] getCupSizeNotIn() {
	        return this.cupSizeNotIn;
        }
        
        public void setCupSizeNotIn(String... cupSizeNotIn) {
        	this.cupSizeNotIn = cupSizeNotIn;
        }
        
        				        public String getCupSizeNot() {
			return cupSizeNot;
		}
	
		public void setCupSizeNot(String cupSizeNot) {
			this.cupSizeNot = cupSizeNot;
		}
	
								public String getCupSizeGreaterThan() {
			return cupSizeGreaterThan;
		}
	
		public void setCupSizeGreaterThan(String cupSizeGreaterThan) {
			this.cupSizeGreaterThan = cupSizeGreaterThan;
		}
		
								public String getCupSizeLessThan() {
			return cupSizeLessThan;
		}
	
		public void setCupSizeLessThan(String cupSizeLessThan) {
			this.cupSizeLessThan = cupSizeLessThan;
		}
	
								public String getCupSizeGreaterEqual() {
			return cupSizeGreaterEqual;
		}
	
		public void setCupSizeGreaterEqual(String cupSizeGreaterEqual) {
			this.cupSizeGreaterEqual = cupSizeGreaterEqual;
		}
	
								public String getCupSizeLessEqual() {
			return cupSizeLessEqual;
		}
	
		public void setCupSizeLessEqual(String cupSizeLessEqual) {
			this.cupSizeLessEqual = cupSizeLessEqual;
		}
	
		public String getCupSizeIsNull() {
			return cupSizeIsNull;
		}
	
		public void setCupSizeIsNull() {
			this.cupSizeIsNull = NULL_VALUE;
		}
	
		public String getCupSizeIsNotNull() {
			return cupSizeIsNotNull;
		}
	
		public void setCupSizeIsNotNull() {
			this.cupSizeIsNotNull = NULL_VALUE;
		}
	
		public String getCupSizeLike() {
			return cupSizeLike;
		}
	
		public void setCupSizeLike(String cupSizeLike) {
			this.cupSizeLike = cupSizeLike;
		}
	
		public String getCupSizeNotLike() {
			return cupSizeNotLike;
		}
	
		public void setCupSizeNotLike(String cupSizeNotLike) {
			this.cupSizeNotLike = cupSizeNotLike;
		}
	
		public String getCupSizeStartWith() {
			return cupSizeStartWith;
		}
	
		public void setCupSizeStartWith(String cupSizeStartWith) {
			this.cupSizeStartWith = cupSizeStartWith;
		}
	
		public String getCupSizeNotStartWith() {
			return cupSizeNotStartWith;
		}
	
		public void setCupSizeNotStartWith(String cupSizeNotStartWith) {
			this.cupSizeNotStartWith = cupSizeNotStartWith;
		}
	
		public String getCupSizeEndWith() {
			return cupSizeEndWith;
		}
	
		public void setCupSizeEndWith(String cupSizeEndWith) {
			this.cupSizeEndWith = cupSizeEndWith;
		}
	
		public String getCupSizeNotEndWith() {
			return cupSizeNotEndWith;
		}
	
		public void setCupSizeNotEndWith(String cupSizeNotEndWith) {
			this.cupSizeNotEndWith = cupSizeNotEndWith;
		}
	
	
	
	
	
	
	
	
	
	
	
	
						        	
    	public String getCupSizeOr() {
	        return this.cupSizeOr;
        }
        
        public void setCupSizeOr(String cupSizeOr) {
        	this.cupSizeOr = cupSizeOr;
        }
        
        				        	
    	public String[] getCupSizeOrIn() {
	        return this.cupSizeOrIn;
        }
        
        public void setCupSizeOrIn(String... cupSizeOrIn) {
        	this.cupSizeOrIn = cupSizeOrIn;
        }
        
        				        	
    	public String[] getCupSizeOrNotIn() {
	        return this.cupSizeOrNotIn;
        }
        
        public void setCupSizeOrNotIn(String... cupSizeOrNotIn) {
        	this.cupSizeOrNotIn = cupSizeOrNotIn;
        }
        
        				        public String getCupSizeOrNot() {
			return cupSizeOrNot;
		}
	
		public void setCupSizeOrNot(String cupSizeOrNot) {
			this.cupSizeOrNot = cupSizeOrNot;
		}
	
								public String getCupSizeOrGreaterThan() {
			return cupSizeOrGreaterThan;
		}
	
		public void setCupSizeOrGreaterThan(String cupSizeOrGreaterThan) {
			this.cupSizeOrGreaterThan = cupSizeOrGreaterThan;
		}
		
								public String getCupSizeOrLessThan() {
			return cupSizeOrLessThan;
		}
	
		public void setCupSizeOrLessThan(String cupSizeOrLessThan) {
			this.cupSizeOrLessThan = cupSizeOrLessThan;
		}
	
								public String getCupSizeOrGreaterEqual() {
			return cupSizeOrGreaterEqual;
		}
	
		public void setCupSizeOrGreaterEqual(String cupSizeOrGreaterEqual) {
			this.cupSizeOrGreaterEqual = cupSizeOrGreaterEqual;
		}
	
								public String getCupSizeOrLessEqual() {
			return cupSizeOrLessEqual;
		}
	
		public void setCupSizeOrLessEqual(String cupSizeOrLessEqual) {
			this.cupSizeOrLessEqual = cupSizeOrLessEqual;
		}
	
		public String getCupSizeOrIsNull() {
			return cupSizeOrIsNull;
		}
	
		public void setCupSizeOrIsNull() {
			this.cupSizeOrIsNull = NULL_VALUE;
		}
	
		public String getCupSizeOrIsNotNull() {
			return cupSizeOrIsNotNull;
		}
	
		public void setCupSizeOrIsNotNull() {
			this.cupSizeOrIsNotNull = NULL_VALUE;
		}
	
		public String getCupSizeOrLike() {
			return cupSizeOrLike;
		}
	
		public void setCupSizeOrLike(String cupSizeOrLike) {
			this.cupSizeOrLike = cupSizeOrLike;
		}
	
		public String getCupSizeOrNotLike() {
			return cupSizeOrNotLike;
		}
	
		public void setCupSizeOrNotLike(String cupSizeOrNotLike) {
			this.cupSizeOrNotLike = cupSizeOrNotLike;
		}
	
		public String getCupSizeOrStartWith() {
			return cupSizeOrStartWith;
		}
	
		public void setCupSizeOrStartWith(String cupSizeOrStartWith) {
			this.cupSizeOrStartWith = cupSizeOrStartWith;
		}
	
		public String getCupSizeOrNotStartWith() {
			return cupSizeOrNotStartWith;
		}
	
		public void setCupSizeOrNotStartWith(String cupSizeOrNotStartWith) {
			this.cupSizeOrNotStartWith = cupSizeOrNotStartWith;
		}
	
		public String getCupSizeOrEndWith() {
			return cupSizeOrEndWith;
		}
	
		public void setCupSizeOrEndWith(String cupSizeOrEndWith) {
			this.cupSizeOrEndWith = cupSizeOrEndWith;
		}
	
		public String getCupSizeOrNotEndWith() {
			return cupSizeOrNotEndWith;
		}
	
		public void setCupSizeOrNotEndWith(String cupSizeOrNotEndWith) {
			this.cupSizeOrNotEndWith = cupSizeOrNotEndWith;
		}
	
	



}