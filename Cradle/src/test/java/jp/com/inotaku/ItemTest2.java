package jp.com.inotaku;

import java.util.Arrays;

import static org.junit.Assert.*;
import jp.com.inotaku.domain.Item;

import org.apache.commons.codec.binary.Base64;
import org.junit.Test;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

public class ItemTest2 {

	private String jsonString = "{\"itemName\":\"Spear\",\"itemType\":\"aa\",\"price\":30000,\"attack\":100,\"defense\":0,\"description\":\"10000\"}";

	static HttpHeaders getHeaders(String auth) {
	    HttpHeaders headers = new HttpHeaders();
	    headers.setContentType(MediaType.APPLICATION_JSON);
	    headers.setAccept(Arrays.asList(MediaType.APPLICATION_JSON));

	    byte[] encodedAuthorisation = Base64.encodeBase64(auth.getBytes());
	    headers.add("Authorization", "Basic " + new String(encodedAuthorisation));

	    return headers;
	}

	@Test
	public void test() {
		HttpEntity<String> requestEntity = new HttpEntity<String>(jsonString,
				getHeaders("letsnosh" + ":" + "noshing"));
		System.out.println(requestEntity);

		RestTemplate template = new RestTemplate();
		ResponseEntity<Item> entity = template
				.postForEntity("http://localhost:8080/Cradle/json/",
						requestEntity, Item.class);
		System.out.println(entity.getHeaders().getLocation());
		/* String path = entity.getHeaders().getLocation().getPath(); */
				 assertEquals(HttpStatus.OK, entity.getStatusCode());
		/* * assertTrue(path.startsWith("/Cradle/json/")); Item item =
		 * entity.getBody();
		 * 
		 * System.out.println("The Item Id is " + item.getItemId());
		 */
		/*
		 * System.out.println("The Location is" +
		 * entity.getHeaders().getLocation());*/
		 
	}
}
