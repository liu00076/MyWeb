package com.centa.agency.core.dto;





import java.io.Serializable;

/**
 * 
 * 
 * 
 * @author 
 * 
 * @version 1.0
 * 
 * @since 2017年09月04日
 */
public class GirlDto  implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = 1L;
	

   

						private Integer id; //${property.comment}


   

						private Integer age; //年龄


   

						private String cupSize; //size


/** 以下为get,set方法 */
    
       		 						
        	
        	 public Integer getId() {
		        return this.id;
	        }
	        public void setId(Integer id) {
	        	this.id = id;
	        }
	

    
       		 						
        	
        	 public Integer getAge() {
		        return this.age;
	        }
	        public void setAge(Integer age) {
	        	this.age = age;
	        }
	

    
       		 						
        	
        	 public String getCupSize() {
		        return this.cupSize;
	        }
	        public void setCupSize(String cupSize) {
	        	this.cupSize = cupSize;
	        }
	


	@Override
	public String toString() {
		return "{'id':" + id + ",'age':" + age + ",'cupSize':'" + cupSize + "'}";
	}


}
