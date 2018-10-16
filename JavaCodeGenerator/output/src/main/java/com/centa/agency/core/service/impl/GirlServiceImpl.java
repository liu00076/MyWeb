package com.centa.agency.core.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.misterfat.springboot.starter.mybatis.core.AbstractBaseService;
import com.misterfat.springboot.starter.mybatis.core.BaseRepository;
 import com.centa.agency.core.dao.GirlDao;
import com.centa.agency.core.entity.Girl;
import com.centa.agency.core.service.GirlService;

@Service
public class GirlServiceImpl extends AbstractBaseService<Girl>
		implements GirlService {

	@Autowired
	private GirlDao girlDao;
	
	   	

	/***********************************************/
	/******                                   ******/
	/**** 请在事务方法上单独加 @Transactional 注解****/
	/******                                   ******/
	/***********************************************/
	
	@Override
	protected BaseRepository<Girl> getRepository() {
		return girlDao;
	}

}


