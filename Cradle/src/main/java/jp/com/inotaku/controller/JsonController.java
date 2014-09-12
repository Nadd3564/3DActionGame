package jp.com.inotaku.controller;

import jp.com.inotaku.service.ItemService;

import org.omg.CORBA.PUBLIC_MEMBER;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;


@Controller
@RequestMapping(value = "/json")
public class JsonController {
	
	@Autowired
	private ItemService itemService;

	@RequestMapping(value = "/{id}",method = RequestMethod.GET)
	public String getItem(@PathVariable long itemId, Model model){
		System.out.println("ジェイソン");
		model.addAttribute(itemService.getItemById(itemId));
		return "item/view";
	}
	
	@RequestMapping(value = "/json")
	public String get(){
		return "item";
	}
	
}
