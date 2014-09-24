package jp.com.inotaku;

import java.util.List;

import jp.com.inotaku.domain.Item;
import jp.com.inotaku.persistence.ItemDao;
import jp.com.inotaku.persistence.ItemDaoImpl;
import jp.com.inotaku.persistence.ItemRepository;
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

@RunWith(MockitoJUnitRunner.class)
public class Test4 {

	@Mock
	private ItemDao itemDao;

	@InjectMocks
	private ItemService ItemService = new ItemServiceImpl();


	@Test
	public void itemDaoTest(){
		Item item = new Item();
		item.setItemName("katana");
		when(itemDao.getAllItem()).thenCallRealMethod();
		
		doReturn(item).when(itemDao).findById(anyLong());
		String ret = ItemService.findById(100).getItemName();
		System.out.println(ret);
	}
}
