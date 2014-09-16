package jp.com.inotaku.controller;

import java.util.List;

import jp.com.inotaku.domain.Item;
import jp.com.inotaku.service.ItemService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
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

	@RequestMapping(value = "/{itemId}", method = RequestMethod.GET)
	@ResponseBody
	public Item getItem(@PathVariable long itemId) {
		return  itemService.getItemById(itemId);
	}
	
	@RequestMapping(value = "/",  method = RequestMethod.POST)
	@ResponseBody
	public Item createIetm(@RequestBody Item item){
		itemService.addItem(item);
		return item;
	}

	@RequestMapping(value = "/itemlist", method = RequestMethod.GET)
	@ResponseBody
	public List<Item> get() {
		return itemService.getAllItem();
	}

}
