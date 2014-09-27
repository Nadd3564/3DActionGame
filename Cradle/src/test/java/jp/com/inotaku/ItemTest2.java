package jp.com.inotaku;


import static org.junit.Assert.*;

import java.util.Arrays;

import jp.com.inotaku.domain.Item;

import org.junit.Test;
import org.springframework.http.*;
import org.springframework.security.crypto.codec.Base64;
import org.springframework.web.client.RestTemplate;


public class ItemTest2 {

	private String jsonString = "{\"itemName\":\"Spear\",\"itemType\":\"aa\","
			+ "\"price\":30000,\"attack\":100,"
			+ "\"defense\":0,\"description\":\"10000\"}";

	static HttpHeaders getHeaders(String auth) {
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		headers.setAccept(Arrays.asList(MediaType.APPLICATION_JSON));

		byte[] encodedAuthorisation = Base64.encode(auth.getBytes());
		headers.add("Authorization", "Basic "
				+ new String(encodedAuthorisation));

		return headers;
	}

	@Test
	public void test() {
		HttpEntity<String> requestEntity = new HttpEntity<String>(jsonString,
				getHeaders("user" + ":" + "user"));

		RestTemplate template = new RestTemplate();
		ResponseEntity<Item> entity = template
				.postForEntity("http://localhost:8080/Cradle/json/",
						requestEntity, Item.class);
		System.out.println(entity.getHeaders().getLocation());
		/* String path = entity.getHeaders().getLocation().getPath(); */
		assertEquals(HttpStatus.OK, entity.getStatusCode());
		/*
		 * * assertTrue(path.startsWith("/Cradle/json/")); Item item =
		 * entity.getBody();
		 * 
		 * System.out.println("The Item Id is " + item.getItemId());
		 */
		/*
		 * System.out.println("The Location is" +
		 * entity.getHeaders().getLocation());
		 */

	}
}
