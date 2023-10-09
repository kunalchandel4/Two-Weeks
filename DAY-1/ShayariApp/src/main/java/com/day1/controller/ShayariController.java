package com.day1.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
@CrossOrigin(origins = "*")
public class ShayariController {
	@Autowired
	private ChatGptClient client;

	@PostMapping("/generateShayari")
	public ResponseEntity<String> generateShayari(@RequestBody KeywordMain keyword) {

		String prompt = "Compose a heartfelt Shayari on the theme of love. Emphasize the beauty of nature and the feelings of longing using the keyword: "
				+ keyword.getName();

		String res = client.talkWithGpt(prompt);
		if (res != null) {
			return ResponseEntity.status(HttpStatus.OK).body(res);
		} else {
			return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("Unable to generate Shayari.");
		}

	}

	@PostMapping("/generateStory")
	public ResponseEntity<String> generateStory(@RequestBody KeywordMain keyword) {

		String prompt = "Write an engaging short story set in a mysterious forest with the protagonist encountering unexpected challenges and finding courage to overcome them."
				+ keyword.getName();

		String res = client.talkWithGpt(prompt);
		if (res != null) {
			return ResponseEntity.status(HttpStatus.OK).body(res);
		} else {
			return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("Unable to generate STory.");
		}

	}

	@PostMapping("/generateQuotes")
	public ResponseEntity<String> generateQuotes(@RequestBody KeywordMain keyword) {

		String prompt = "Create an inspiring quote about life and success, highlighting the power of perseverance and determination. Use the keyword: "
				+ keyword.getName() + " to add a personalized touch.";

		String res = client.talkWithGpt(prompt);
		if (res != null) {
			return ResponseEntity.status(HttpStatus.OK).body(res);
		} else {
			return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("Unable to generate Quote.");
		}

	}

}
