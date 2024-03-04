# Questionnaire Endpoints

This API provides endpoints to manage questions and answers in a questionnaire.

## Docker

To run the application using Docker, follow these steps:

1. Make sure Docker is installed on your machine.

2. Clone the repository.

3. Navigate to the root directory of the project (/src)

4. In the 'src' folder, there should be 2 items - (DockerFile / run.sh)

4. Execute the `run.sh` bash script:

    ```bash
    ./run.sh
    ```

5. Once the script completes, the API will be accessible at `http://localhost:5000`.

6. You can now use the provided endpoints to interact with the API.

## Endpoints

### Get Questions

Retrieves a list of questions grouped by their titles.

- **URL:** `/api/questions`
- **Method:** `GET`
- **Success Response:**
  - **Code:** 200 OK
  - **Content:** Array of grouped questions
  
### Get Advanced Questions

Retrieves advanced information about questions, including their GUIDs.

- **URL:** `/api/questions/advanced`
- **Method:** `GET`
- **Success Response:**
  - **Code:** 200 OK
  - **Content:** Array of questions with their GUIDs
  
### Get Question by ID

Retrieves a question by its GUID.

- **URL:** `/api/questions/{guid}`
- **Method:** `GET`
- **URL Params:** `guid` - GUID of the question
- **Success Response:**
  - **Code:** 200 OK
  - **Content:** Question details
  
### Answer Question

Submits an answer to a question.

- **URL:** `/api/questions/{guid}`
- **Method:** `POST`
- **URL Params:** `guid` - GUID of the question
- **Data Params:** `answer` - The answer provided by the user
- **Success Response:**
  - **Code:** 200 OK
  - **Content:** Acknowledgment of answer submission