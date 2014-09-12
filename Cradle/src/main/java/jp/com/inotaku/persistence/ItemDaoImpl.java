package jp.com.inotaku.persistence;

import java.sql.Timestamp;
import java.util.Calendar;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import jp.com.inotaku.domain.Item;

import org.springframework.stereotype.Component;

@Component
public class ItemDaoImpl implements ItemDao {

	@PersistenceContext
	EntityManager em;

	@SuppressWarnings("unchecked")
	public List<Item> getAllItem() {
		return em.createQuery("from Item").getResultList();
	}

	public void addItem(Item item) {
		Timestamp currentTime = new Timestamp(Calendar.getInstance()
				.getTimeInMillis());
		item.setUpdateTime(currentTime);
		em.persist(item);
	}

	public Item findById(long id) {
		return (Item) em.createQuery("from Item where itemId = :itemId")
				.setParameter("itemId", id).getSingleResult();
	}

	public void update(Item item) {
		item.setUpdateTime(new Timestamp(Calendar.getInstance().getTimeInMillis()));
		em.merge(item);
	}

	public void delete(long itemId) {
		Item item = findById(itemId);
		em.remove(item);
	}

	@SuppressWarnings("unchecked")
	public List<Item> findByName(String itemName) {
		return em.createQuery("from Item where itemName like :itemName")
				.setParameter("itemName", "%" + itemName + "%").getResultList();
	}

}
