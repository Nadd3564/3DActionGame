package jp.com.inotaku.service;

import java.util.List;

import jp.com.inotaku.domain.Item;

public interface ItemService {

	public abstract void addItem(Item item);

	public abstract void updateItem(Item item);

	public abstract Item findById(long itemId);

	public abstract void delete(long itemId);

	public abstract List<Item> getItemByItemName(String itemName);

	public abstract Item getItemById(long itemId);

	public abstract List<Item> getAllItem();
	

}