package jp.com.inotaku.service;

import java.util.List;

import jp.com.inotaku.domain.Item;
import jp.com.inotaku.persistence.ItemDao;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional(propagation=Propagation.REQUIRED)
public class ItemServiceImpl implements ItemService {

	@Autowired
	ItemDao itemDao;
	
	
	public void addItem(Item item){
		itemDao.addItem(item);
	}


	public void updateItem(Item item) {
		itemDao.update(item);
	}


	public Item findById(long itemId) {
		return itemDao.findById(itemId);
	}


	public void delete(long itemId) {
		itemDao.delete(itemId);
	}


	public List<Item> getItemByItemName(String itemName) {
		return itemDao.findByName(itemName);
	}


	public Item getItemById(long itemId) {
		return itemDao.findById(itemId);
	}


	public List<Item> getAllItem() {
		return itemDao.getAllItem();
	}
	
}
