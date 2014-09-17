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

	/*
	 * private String jsonString =
	 * "{\"itemId\":4,\"itemName\":\"ルーンソード\",\"itemType\":\"武器\",\"price\":300,\"attack\":10,\"defense\":0,\"description\":\"攻撃力が10上昇する\",\"updateTime\":1410346214000}"
	 * ;
	 */
	private String jsonString = "";

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

		String path = entity.getHeaders().getLocation().getPath();

		assertEquals(HttpStatus.CREATED, entity.getStatusCode());
		assertTrue(path.startsWith("/Cradle/json/"));
		Item item = entity.getBody();

		System.out.println("The Item ID is " + item.getItemId());
		System.out.println("The Location is "
				+ entity.getHeaders().getLocation());

	}
}
