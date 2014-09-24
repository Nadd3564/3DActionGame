package jp.com.inotaku;

import java.util.List;

import jp.com.inotaku.domain.Item;
import jp.com.inotaku.persistence.ItemDao;
import jp.com.inotaku.persistence.ItemDaoImpl;
import jp.com.inotaku.service.ItemService;
import jp.com.inotaku.service.ItemServiceImpl;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.kubek2k.springockito.annotations.ReplaceWithMock;
import org.kubek2k.springockito.annotations.SpringockitoAnnotatedContextLoader;
import org.kubek2k.springockito.annotations.SpringockitoContextLoader;
import org.kubek2k.springockito.annotations.WrapWithSpy;

import static org.junit.Assert.*;
import static org.mockito.Matchers.*;
import static org.mockito.Mockito.*;

import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.MockitoAnnotations;
import org.mockito.Spy;
import org.mockito.runners.MockitoJUnitRunner;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"classpath:spring/*.xml","WEB-INF.*.xml"},
loader = SpringockitoContextLoader.class)
public class Test3 {

	
	@ReplaceWithMock
	@Autowired
	private ItemDao itemDao;
	
	@Autowired
	private ItemService ItemService;
	
	@Autowired
	private ItemDaoImpl dao;
	
	
	@Test
	public void testfindById() {
		Item item = new Item();
		item.setItemName("katana");
		
/*		doReturn(item).when(itemDao).findById(anyLong());*/
		doReturn(dao.getAllItem()).when(itemDao).getAllItem();
		
		when(itemDao.findById(anyLong())).thenReturn(item);
		List<Item> itemlist = ItemService.getAllItem();
		System.out.println(itemlist);
		String ret = ItemService.findById(100).getItemName();
		System.out.println(ret);
		
		verify(itemDao).findById(100);
		verify(itemDao,never()).addItem(item);
		verify(itemDao).getAllItem();
		assertEquals("katana", ret);
	}

}
