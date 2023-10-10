package com.code.controllerSnipt;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@CrossOrigin("*")
public class CodeSniptController {

	@Autowired
	private ChatGptClient client;

	@PostMapping("/convert")
	public ResponseEntity<String> convertCode(@RequestBody CodeEntity code, @RequestParam String language) {
		// Call ChatGPT API to convert the code based on the selected language
		// You'll need to implement this part based on your API integration with ChatGPT
		// Return the converted code

		String prompt = "Please convert the following code into  the " + language + " language  and this is the Code : " + code.getCode() + "and  please give me the converted code ? ";
		System.out.println("=============== >>>> :" + prompt);
		String res = client.talkWithGpt(prompt);

		System.out.println(" kunal :  --- " + res);
		if (res != null)

			return new ResponseEntity<>("Converted code for " + language + ":\n" + res,
					org.springframework.http.HttpStatus.OK);

		else

			return new ResponseEntity<>("Something wrong", org.springframework.http.HttpStatus.INTERNAL_SERVER_ERROR);

	}

	@PostMapping("/qualitycheck")
	public ResponseEntity<String> codeQualityCheck(@RequestBody CodeEntity code) {
		// Call ChatGPT API to convert the code based on the selected language
		// You'll need to implement this part based on your API integration with ChatGPT
		// Return the converted code

		String prompt = "Can you please check the quality of  this code " + code.getCode()
				+ "By following these points and can you give detailed result in term of percentage"
				+ "1. Code Readability and Maintainability:"
				+ "Description: Code should be easy to read, understand, and maintain by developers other than the original authors. It should follow consistent naming conventions, proper indentation, and well-organized structure."
				+ "Importance: Readable and maintainable code reduces the time and effort required for modifications, debugging, and collaboration, ultimately improving the software's long-term maintainability"
				+ "2.Modularity and Reusability:"
				+ "Description: Code should be organized into small, manageable modules that encapsulate specific functionality. These modules should be easily reusable in different parts of the application or in other projects."
				+ "Importance: Modularity and reusability enhance code efficiency, reduce redundancy, and improve scalability, as well as facilitate faster development by leveraging existing, tested components"
				+ "3.Error Handling and Robustness:"
				+ "Description: Code should effectively handle errors and exceptions to prevent crashes or unexpected behavior. It should provide clear error messages and gracefully handle exceptional conditions."
				+ "Importance: Proper error handling enhances the application's stability, reliability, and user experience. It ensures that the application fails gracefully and helps in identifying and resolving issues quickly."
				+ "4.Optimized Performance:"
				+ "Description: Code should be optimized for performance, considering factors such as speed, memory usage, and efficiency. Performance improvements should be based on data-driven decisions and profiling results."
				+ "Importance: Optimized code ensures a responsive application, improves user satisfaction, and can lead to cost savings by reducing the need for additional hardware or server resources."
				+ "5.Adherence to Coding Standards and Best Practices"
				+ "Description: Code should adhere to established coding standards, guidelines, and best practices specific to the programming language or framework being used. These may cover naming conventions, design patterns, security practices, and more."
				+ "Importance: Following coding standards ensures consistency, facilitates collaboration, and promotes a common understanding of the codebase across the development team. It also helps in identifying and rectifying potential issues early in the development process";

		String res = client.talkWithGpt(prompt);
		if (res != null)

			return new ResponseEntity<>("Quality Check feature for this [\n " + code + "]:\n" + res,
					org.springframework.http.HttpStatus.OK);

		else

			return new ResponseEntity<>("Something wrong", org.springframework.http.HttpStatus.INTERNAL_SERVER_ERROR);

	}

	@PostMapping("/debug")
	public ResponseEntity<String> codedebug(@RequestBody CodeEntity code) {
		// Call ChatGPT API to convert the code based on the selected language
		// You'll need to implement this part based on your API integration with ChatGPT
		// Return the converted code

		String prompt = "Can you please Debug this code " + code.getCode()
				+ " and give me detail imformantion what went wrong and how to resolve it.";

		String res = client.talkWithGpt(prompt);
		if (res != null)

			return new ResponseEntity<>("Debugging feature for this code [\n" + code + "]:\n" + res,
					org.springframework.http.HttpStatus.OK);

		else

			return new ResponseEntity<>("Something wrong", org.springframework.http.HttpStatus.INTERNAL_SERVER_ERROR);

	}
}
