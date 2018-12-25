package com.centa.agency.core.service;

import java.io.Serializable;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;
import com.yilaiok.spring.boot.starter.mybatis.Pagelist;
import com.centa.agency.core.entity.Girl;
import com.centa.agency.core.qo.GirlQo;


@RunWith(SpringRunner.class)
@SpringBootTest
public class GirlServiceTest {
	
	@Autowired
	private GirlService girlService;

	@Test
	public void testInsert() {
		Girl girl = new Girl();
		girlService.insert(girl);
	}

	@Test
	public void testInsertSelective() {
		Girl girl = new Girl();
		girlService.insertSelective(girl);
	}

	@Test
	public void testUpdate() {
		Girl girl = new Girl();
		girlService.update(girl);
	}

	@Test
	public void testUpdateSelective() {
		Girl girl = new Girl();
		girlService.updateSelective(girl);
	}


	@Test
	public void testDeleteById() {
		String id = "";
		girlService.deleteById(id);
	}

	@Test
	public void testBatchDelete() {
		Serializable[] ids = new String[] {};
		girlService.batchDelete(ids);
	}

	@Test
	public void testFindAll() {
		List<Girl> list = girlService.findAll();
		if (list != null && !list.isEmpty()) {
			for (Girl girl : list) {
				System.out.println(girl.getId());
			}
		}
	}

	@Test
	public void testFindById() {
		Serializable id = "";
		Girl girl = girlService.findById(id);
		System.out.println(girl.getId());
	}

	@Test
	public void testFindList() {
		GirlQo girlQo = new GirlQo();
		List<Girl> list = girlService.findList(girlQo);
		if (list != null && !list.isEmpty()) {
			for (Girl girl : list) {
				System.out.println(girl.getId());
			}
		}
	}

	@Test
	public void testFindTotalCount() {
		int totalCount = girlService.findTotalCount();
		System.out.println(totalCount);
	}

	@Test
	public void testFindCount() {
		GirlQo girlQo = new GirlQo();
		int totalCount = girlService.findCount(girlQo);
		System.out.println(totalCount);
	}

	@Test
	public void testFindPaginationList() {
		GirlQo query = new GirlQo();
		Pagelist<Girl> pagelist = girlService
				.findPaginationList(query);
		System.out.println(pagelist);
	}


}
