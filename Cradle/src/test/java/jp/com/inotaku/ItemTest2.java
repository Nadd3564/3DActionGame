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

	private String jsonString = "{\"itemId\":4,\"itemName\":\"ルーンソード\",\"itemType\":\"武器\",\"price\":300,\"attack\":10,\"defense\":0,\"description\":\"攻撃力が10上昇する\",\"updateTime\":1410346214000}";

	static HttpHeaders getHeaders(String auth) {
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		headers.setAccept(Arrays.asList(MediaType.APPLICATION_JSON));
		byte[] encodeedAuthorisation = Base64.encodeBase64(auth.getBytes());
		headers.add("Authorization", "Basic "
				+ new String(encodeedAuthorisation));
		System.out.println(headers);
		return headers;
	}

	@Test
	public void test() {
		HttpEntity<String> requestEntity = new HttpEntity<String>(jsonString,
				 getHeaders("letsnosh" + ":" + "noshing"));

		RestTemplate template = new RestTemplate();
		ResponseEntity<Item> entity = template
				.postForEntity("http://localhost:8080/Cradle/json/",
						requestEntity, Item.class);

		String path = entity.getHeaders().getLocation().getPath();

		assertEquals(HttpStatus.CREATED, entity.getStatusCode());
		assertTrue(path.startsWith("/Cradle/json/"));
		Item item = entity.getBody();

		System.out.println("The Item Id is " + item.getItemId());
		System.out.println("The Location is"
				+ entity.getHeaders().getLocation());

	}
}
