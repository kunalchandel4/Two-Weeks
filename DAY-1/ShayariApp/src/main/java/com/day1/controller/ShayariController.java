package com.day1.controller;

import java.net.URI;

import org.apache.http.HttpEntity;
import org.apache.http.HttpHeaders;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.util.EntityUtils;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;

@RestController
@CrossOrigin(origins = "*")
public class ShayariController {

	@Value("${gpt3.api.endpoint}")
	private String gpt3ApiEndpoint;

	@PostMapping("/generateShayari")
	public ResponseEntity<String> generateShayari(@RequestBody String keyword) {
		try (CloseableHttpClient httpClient = HttpClients.createDefault()) {

			HttpPost httpPost = new HttpPost();
			URI uri = new URI(gpt3ApiEndpoint);
			httpPost.setURI(uri);

			// Set the necessary headers, including the Authorization header

			httpPost.addHeader(HttpHeaders.AUTHORIZATION, "Bearer YOUR_API_KEY"); // Replace with your actual GPT-3 API

			String prompt = "Act as a Shayar and Generate Shayari based on the keyword: " + keyword;
			httpPost.setEntity(new StringEntity("{\"prompt\": \"" + prompt + "\", \"max_tokens\": 50}", "UTF-8"));

			CloseableHttpResponse response = httpClient.execute(httpPost);
			HttpEntity entity = response.getEntity();

			if (entity != null) {
				String responseBody = EntityUtils.toString(entity);
				System.out.println("Response: " + responseBody);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ResponseEntity.status(HttpStatus.OK).body("SHayar ka SHayar");

	}

	@PostMapping("/generateStory")
	public ResponseEntity<String> generateStory(@RequestBody String keyword) {
		try (CloseableHttpClient httpClient = HttpClients.createDefault()) {

			HttpPost httpPost = new HttpPost();
			URI uri = new URI(gpt3ApiEndpoint);
			httpPost.setURI(uri);

			// Set the necessary headers, including the Authorization header

			httpPost.addHeader(HttpHeaders.AUTHORIZATION, "Bearer YOUR_API_KEY"); // Replace with your actual GPT-3 API

			String prompt = "Act as a Story teller and Generate Shayari based on the keyword: " + keyword;
			httpPost.setEntity(new StringEntity("{\"prompt\": \"" + prompt + "\", \"max_tokens\": 50}", "UTF-8"));

			CloseableHttpResponse response = httpClient.execute(httpPost);
			HttpEntity entity = response.getEntity();

			if (entity != null) {
				String responseBody = EntityUtils.toString(entity);
				System.out.println("Response: " + responseBody);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ResponseEntity.status(HttpStatus.OK).body("STORY ki STories");

	}

	@PostMapping("/generateQuotes")
	public ResponseEntity<String> generateQuotes(@RequestBody String keyword) {
		try (CloseableHttpClient httpClient = HttpClients.createDefault()) {

			HttpPost httpPost = new HttpPost();
			URI uri = new URI(gpt3ApiEndpoint);
			httpPost.setURI(uri);

			// Set the necessary headers, including the Authorization header

			httpPost.addHeader(HttpHeaders.AUTHORIZATION, "Bearer YOUR_API_KEY"); // Replace with your actual GPT-3 API
			// key
			// Set the request body (e.g., your prompt)
			String prompt = "Act as a Quotes teller and Generate Shayari based on the keyword: " + keyword;
			httpPost.setEntity(new StringEntity("{\"prompt\": \"" + prompt + "\", \"max_tokens\": 50}", "UTF-8"));

			CloseableHttpResponse response = httpClient.execute(httpPost);
			HttpEntity entity = response.getEntity();

			if (entity != null) {
				String responseBody = EntityUtils.toString(entity);
				System.out.println("Response: " + responseBody);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ResponseEntity.status(HttpStatus.OK).body("Quotes ki Quotes");

	}

	private String extractShayariFromResponse(String responseBody) {
		// Parse and extract the Shayari from the GPT-3.5 response
		// Implement the logic to extract Shayari based on the response structure
		// Return the extracted Shayari
		System.out.println("Kunal :: " + responseBody);

		try {
			ObjectMapper objectMapper = new ObjectMapper();
			JsonNode responseJson = objectMapper.readTree(responseBody);

			// Extract the choices array from the GPT-3.5 response
			JsonNode choices = responseJson.get("choices");

			// Check if choices is not null and has at least one item
			if (choices != null && choices.isArray() && choices.size() > 0) {
				// Extract the generated Shayari from the first choice (index 0)
				JsonNode firstChoice = choices.get(0);
				JsonNode text = firstChoice.get("text");

				// Return the extracted Shayari
				if (text != null) {
					return text.asText();
				}
			}
		} catch (JsonProcessingException e) {
			// Handle JSON parsing exception
			e.printStackTrace();
		}

		return "Unable to extract Shayari from the response.";
	}
}
