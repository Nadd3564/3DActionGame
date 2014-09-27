package jp.com.inotaku;

import static junit.framework.TestCase.assertEquals;
import static junit.framework.TestCase.assertTrue;

import java.util.Arrays;

import jp.com.inotaku.domain.Item;

import org.junit.Test;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

public class ItemTest1 {

	private String jsonString = "{\"itemName\":\"Spear\",\"itemType\":\"aa\",\"price\":30000,\"attack\":100,\"defense\":0,\"description\":\"10000\"}";
	

	@Test
	public void thatOrdersCanBeAddedAndQueried() {
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		headers.setAccept(Arrays.asList(MediaType.APPLICATION_JSON));

		RestTemplate template = new RestTemplate();

	HttpEntity<String> requestEntity = new HttpEntity<String>(jsonString,
				headers);

		ResponseEntity<Item> entity = template
				.postForEntity("http://localhost:8080/Cradle/json/",
						requestEntity, Item.class);
		
		System.out.println(entity.getHeaders().getLocation().getPath());

	/*	String path = entity.getHeaders().getLocation().getPath();

		assertEquals(HttpStatus.OK, entity.getStatusCode());
		assertTrue(path.startsWith("/Cradle/json/"));
		Item item = entity.getBody();

		System.out.println("The Item ID is " + item.getItemId());
		System.out.println("The Location is "
				+ entity.getHeaders().getLocation());*/

	}
}
