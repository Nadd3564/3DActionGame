package jp.com.inotaku.persistence;

import java.util.List;

import jp.com.inotaku.domain.Item;

public interface ItemDao {
	
	List<Item> getAllItem();

	void addItem(Item item);
	Item findById(long id);

	void update(Item item);

	void delete(long itemId);

	List<Item> findByName(String itemName);
	

}
