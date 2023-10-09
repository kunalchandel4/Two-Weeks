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
import org.springframework.stereotype.Component;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.node.ArrayNode;
import com.fasterxml.jackson.databind.node.JsonNodeFactory;
import com.fasterxml.jackson.databind.node.ObjectNode;


@Component
public class ChatGptClient {

	private String endpoint = "https://api.openai.com/v1/chat/completions";

	private String apiKey = "PUT-YOUR-APIKEY";

	public String talkWithGpt(String prompt) {

		try (CloseableHttpClient httpClient = HttpClients.createDefault()) {
			HttpPost httpPost = new HttpPost();
			URI uri = new URI(endpoint);
			httpPost.setURI(uri);

			// Set the necessary headers, including the Authorization header
			httpPost.addHeader(HttpHeaders.AUTHORIZATION, "Bearer PUT-YOUR-APIKEY");
			// key
			httpPost.addHeader(HttpHeaders.CONTENT_TYPE, "application/json"); // Set the correct Content-Type
			ObjectNode jsonPayload = JsonNodeFactory.instance.objectNode();
			ArrayNode messagesArray = jsonPayload.putArray("messages");

			// Add a system message
			ObjectNode systemMessage = JsonNodeFactory.instance.objectNode();
			systemMessage.put("role", "system");
			systemMessage.put("content", "You are a helpful assistant.");
			messagesArray.add(systemMessage);

			// Add the user's message
			ObjectNode userMessage = JsonNodeFactory.instance.objectNode();
			userMessage.put("role", "user");
			userMessage.put("content", prompt);
			messagesArray.add(userMessage);

			jsonPayload.put("max_tokens", 200); // Adjust max_tokens to control the length of the generated text
			jsonPayload.put("temperature", 0.7); // Experiment with temperature
			jsonPayload.put("model", "gpt-3.5-turbo"); // Specify the GPT-3.5 model

			httpPost.setEntity(new StringEntity(jsonPayload.toString(), "UTF-8"));

			try (CloseableHttpResponse response = httpClient.execute(httpPost)) {
				HttpEntity entity = response.getEntity();

				if (entity != null) {
					String responseBody = EntityUtils.toString(entity);
					System.out.println("Response: " + responseBody);

					// Extract ans from the response
					String ans = extractShayariFromResponse(responseBody);
					return ans;
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;

	}

	private String extractShayariFromResponse(String responseBody) {
	    try {
	        ObjectMapper objectMapper = new ObjectMapper();
	        JsonNode responseJson = objectMapper.readTree(responseBody);

	        JsonNode choices = responseJson.get("choices");

	        if (choices != null && choices.isArray() && choices.size() > 0) {
	            JsonNode firstChoice = choices.get(0);
	            JsonNode message = firstChoice.get("message");

	            if (message != null) {
	                JsonNode content = message.get("content");
	                if (content != null) {
	                    return content.asText();
	                }
	            }
	        }
	    } catch (JsonProcessingException e) {
	        e.printStackTrace();
	    }

	    return "Unable to extract content from the response.";
	}


}
