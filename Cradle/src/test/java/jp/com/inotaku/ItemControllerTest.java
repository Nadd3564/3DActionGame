package jp.com.inotaku;

import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;

import java.util.List;

import javax.swing.tree.ExpandVetoException;

import jp.com.inotaku.domain.Item;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.web.WebAppConfiguration;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.ui.ModelMap;
import org.springframework.web.context.WebApplicationContext;

import static org.springframework.test.web.servlet.setup.MockMvcBuilders.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;
import static org.springframework.test.web.servlet.result.ModelResultMatchers.*;

@RunWith(SpringJUnit4ClassRunner.class)
@WebAppConfiguration
@ContextConfiguration(locations = { "classpath:spring/*.xml", "WEB-INF.*.xml" })
public class ItemControllerTest {

	@Autowired
	private WebApplicationContext wac;

	private MockMvc mockMvc;

	@Before
	public void setup() {
		mockMvc = MockMvcBuilders.webAppContextSetup(wac).build();
	}

	@Test
	public void getTest() throws Exception {
		MvcResult mvcResult = mockMvc.perform(get("/item/")).andDo(print())
				.andExpect(status().isOk()).andExpect(view().name("item"))
				.andExpect(model().hasNoErrors())
				.andExpect(model().attributeExists("itemlist")).andReturn();

		ModelMap modelMap = mvcResult.getModelAndView().getModelMap();

		Object obj = modelMap.get("itemlist");
		assertThat(obj, is(not(nullValue())));

		@SuppressWarnings("unchecked")
		List<Item> itemlist = (List<Item>) obj;
		assertThat(itemlist.get(0).getItemName(), is("ルーンソード"));
	}



}
