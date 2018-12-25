package com.centa.agency.core.controller.user;

import java.io.Serializable;

import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import com.misterfat.pagination.PaginationInterface;
import com.misterfat.result.Result;
import com.centa.agency.core.dto.GirlDto;
import com.centa.agency.core.entity.Girl;
import com.centa.agency.core.qo.GirlQo;
import com.centa.agency.core.service.GirlService;

/**
 * 
 * ${tableModel.comment}信息控制器（User）
 *
 * @author 
 *
 * @version
 *
 * @since 2017年09月04日
 */
@Controller
public class GirlUserController {

	@Autowired
	private GirlService girlService;

	/**
	 * 
	 * 功能描述：列表
	 * 
	 * @return
	 * 
	 * @author 
	 * 
	 * @since 2016年04月26日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@RequestMapping("user/girl/pagelist")
	@ResponseBody
	public PaginationInterface pagelist(@RequestBody GirlQo qo) {
		return girlService.findPaginationDataByCondition(qo);
	}

	/**
	 * 
	 * 功能描述：详情
	 *
	 * @param id
	 * @return
	 * 
	 * @author 
	 *
	 * @since 2017年09月04日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@RequestMapping("user/girl/detail")
	@ResponseBody
	public Result detail(@RequestParam String id) {

		return Result.valueOf(Result.SUCCESS, girlService.findById(id));
	}

	/**
	 * 
	 * 功能描述：批量删除
	 *
	 * @param id
	 * @return
	 * 
	 * @author 
	 *
	 * @since 2017年09月04日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@RequestMapping("user/girl/batch_delete")
	@ResponseBody
	public Result batchDelete(@RequestParam Serializable... ids) {

		girlService.batchDelete(ids);

		return Result.valueOf(Result.SUCCESS, "操作成功");
	}

	/**
	 * 
	 * 功能描述：删除
	 *
	 * @param id
	 * @return
	 * 
	 * @author 
	 *
	 * @since 2017年09月04日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@RequestMapping("user/girl/delete")
	@ResponseBody
	public Result delete(@RequestParam String id) {

		girlService.deleteByID(id);

		return Result.valueOf(Result.SUCCESS, "操作成功");
	}

	/**
	 * 
	 * 功能描述：添加
	 *
	 * @param id
	 * @return
	 * 
	 * @author 
	 *
	 * @since 2017年09月04日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@RequestMapping("user/girl/add")
	@ResponseBody
	public Result add(@RequestBody GirlDto dto) {

		Girl girl = new Girl();
		BeanUtils.copyProperties(dto, girl);
		girlService.insert(girl);

		return Result.valueOf(Result.SUCCESS, "操作成功");
	}

	/**
	 * 
	 * 功能描述：修改
	 *
	 * @param id
	 * @return
	 * 
	 * @author 
	 *
	 * @since 2017年09月04日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@RequestMapping("user/girl/edit")
	@ResponseBody
	public Result edit(@RequestBody GirlDto dto) {

		Girl girl = new Girl();
		BeanUtils.copyProperties(dto, girl);
		girlService.updateSelective(girl);

		return Result.valueOf(Result.SUCCESS, "操作成功");
	}

}
