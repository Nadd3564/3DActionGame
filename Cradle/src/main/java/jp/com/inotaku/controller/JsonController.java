package jp.com.inotaku.controller;

import java.util.List;
import java.util.Map;
import java.util.Set;

import jp.com.inotaku.domain.Item;
import jp.com.inotaku.service.ItemService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.ResponseStatus;

@Controller
@RequestMapping(value = "/json")
public class JsonController {

	@Autowired
	private ItemService itemService;

	@RequestMapping(value = "/{itemId}", method = RequestMethod.GET, headers = "Accept=application/json")
	public @ResponseBody Item getItem(@PathVariable long itemId) {
		return itemService.getItemById(itemId);
	}

	@RequestMapping(value = "/", method = RequestMethod.POST, headers = "Content-Type=application/json")
	public @ResponseBody Item createItem(@RequestBody Item item) {
		itemService.addItem(item);
		return item;
	}
	
	@RequestMapping(value = "/{itemId}", method = RequestMethod.PUT, headers = "Content-Type=application/json")
	public @ResponseBody Item updateItem(@PathVariable long itemId,@RequestBody Item item){
		item.setItemId(itemId);
		itemService.updateItem(item);
		return item;
	}
	
	@RequestMapping(value = "/{itemId}", method = RequestMethod.DELETE)
	public @ResponseBody Item deleteItem(@PathVariable long itemId){
		Item item = itemService.getItemById(itemId);
		itemService.delete(itemId);
		return item;
		
	}
	@RequestMapping(value = "/itemlist", method = RequestMethod.GET)
	@ResponseBody
	public List<Item> get() {
		return itemService.getAllItem();
	}

}
