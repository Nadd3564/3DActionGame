package jp.com.inotaku.controller;

import java.util.List;

import jp.com.inotaku.domain.Item;
import jp.com.inotaku.persistence.ItemDao;
import jp.com.inotaku.service.ItemService;

import org.hibernate.loader.custom.Return;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping
public class ItemController {
	
	
	@Autowired
	private ItemService itemService;
	

	@RequestMapping(value = "/item", method = RequestMethod.GET)
	public String item(Model model){
		List<Item> itemlist = itemService.getAllItem();
		model.addAttribute("itemlist",itemlist);
		return "item";
	}
	
	@RequestMapping(value = "/create", method = RequestMethod.GET)
	public String create(Model model){
		model.addAttribute("item",new Item());
		return "create";
	}
	
	@RequestMapping(value = "/create", method = RequestMethod.POST)
	public String register(@ModelAttribute Item item, Model model){
		itemService.addItem(item);
		return "redirect:/item";
	}
	
	@RequestMapping(value = "/update", method = RequestMethod.GET)
	public String edit(long itemId,Model model){
		Item item = itemService.getItemById(itemId);
		model.addAttribute("item",item);
		return "update";
	}
	
	@RequestMapping(value ="update", method = RequestMethod.POST)
	public String update(@ModelAttribute Item item, Model model){
		itemService.updateItem(item);
		return "redirect:/item";
	}
	 
	@RequestMapping(value = "delete", method = RequestMethod.GET)
	public String confim(long itemId,Model model){
		Item item = itemService.findById(itemId);
		model.addAttribute("item",item);
		return "delete";
	}
	@RequestMapping(value = "delete", method = RequestMethod.POST)
	public String delete(@ModelAttribute Item item,Model model){
		itemService.delete(item.getItemId());
		return "redirect:/item";
	}
	
	@RequestMapping(value = "search", method = RequestMethod.POST)
	public String search(String itemName,Model model){
		if(itemName == null || itemName.equals("")){
			return "redirect:item";
		}
		
		List<Item> itemlist = itemService.getItemByItemName(itemName);
		model.addAttribute("itemlist", itemlist);
		return "item";
	}
	
	
}
