package jp.com.inotaku;

import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;
import static org.hamcrest.Matchers.*;

import java.util.List;
import java.util.Map;

import javax.swing.tree.ExpandVetoException;

import jp.com.inotaku.domain.Item;

import org.apache.commons.jxpath.JXPathContext;
import org.codehaus.jackson.map.ObjectMapper;
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
@ContextConfiguration(locations = { "classpath:spring/*.xml",
		"file:src/main/webapp/WEB-INF/mvc-config.xml" })
public class JsonControllerTest {

	@Autowired
	private WebApplicationContext wac;

	private MockMvc mockMvc;

	@Before
	public void setup() {
		mockMvc = MockMvcBuilders.webAppContextSetup(wac).build();
	}

	@Test
	public void getTest() throws Exception {
		mockMvc.perform(get("/json/itemlist")).andDo(print())
				.andExpect(jsonPath("$").isArray())
				.andExpect(jsonPath("$[1].itemName").value("カタナ"));

	}

	@Test
	public void posTest() throws Exception {
		Item item = new Item("やり", "武器", 3000, 300, 10, "攻撃力が300上昇する");
		ObjectMapper mapper = new ObjectMapper();
		String jsonString = mapper.writerWithDefaultPrettyPrinter()
				.writeValueAsString(item);
		System.out.println(jsonString);
		System.out.println(jsonString.toString());
		MvcResult mvcResult = mockMvc.perform(
				post("/json/").contentType(MediaType.APPLICATION_JSON).content(
						jsonString.getBytes())).andDo(print())
				.andExpect(jsonPath("$.itemName").value(item.getItemName())).andReturn();
		
		String response = mvcResult.getResponse().getContentAsString();
		@SuppressWarnings("unchecked")
		Map<String, Object> itemdata = mapper.readValue(response, Map.class);
		JXPathContext jxContext = JXPathContext.newContext(itemdata);
		String itemId = jxContext.getValue("itemId").toString();
		
		Item item2 = new Item("盾", "防具", 1000, 0, 100, "防御力が100上昇");
		String jsonString2 = mapper.writerWithDefaultPrettyPrinter().writeValueAsString(item2);
		mockMvc.perform(put("/json/" + itemId).contentType(MediaType.APPLICATION_JSON).content(jsonString2.getBytes())).andDo(print())
		.andExpect(jsonPath("$.itemName").value(item2.getItemName()));
		
		mockMvc.perform(delete("/json/" + itemId )).andDo(print());
	}

}
