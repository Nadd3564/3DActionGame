package jp.com.inotaku.controller;

import java.util.List;

import jp.com.inotaku.domain.Item;
import jp.com.inotaku.service.ItemService;

import org.omg.CORBA.PUBLIC_MEMBER;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
@RequestMapping(value = "/json")
public class JsonController {

	@Autowired
	private ItemService itemService;

	@RequestMapping(value = "/{id}", method = RequestMethod.GET, 
			headers = { "Accept=text/xml,application/json" })
	public @ResponseBody Item getItem(@PathVariable long itemId) {
		return (Item) itemService.getItemById(itemId);
	}

	@RequestMapping(value = "/itemlist", method = RequestMethod.GET)
	@ResponseBody
	public String get(Model model) {
		List<Item> itemlist = itemService.getAllItem();
		model.addAttribute("itemlist", itemlist);
		return "items";
	}

}
