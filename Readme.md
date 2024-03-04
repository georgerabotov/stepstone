# Questionnaire Endpoints

This API provides endpoints to manage questions and answers in a questionnaire.

## Docker

To run the application using Docker, follow these steps:

1. Make sure Docker is installed on your machine.

2. Clone the repository.

3. Navigate to the root directory of the project (/src)

4. In the `src` folder, there should be 2 files 

    ```
        ./Dockerfile
        ./run.sh
    ```

4. Execute the `run.sh` bash script:

    ```bash
    ./run.sh
    ```

Essentially, It will simply run the `DockerFile` file, which creates an image.
Or you can just open 'cmd' - Windows Terminal, if you are using Windows, and just navigate to the folder cd <folder_location>, then just write 'run.sh' and it will run.

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

#### Assumptions
1. As mentioned, I simply mocked the data.
2. I assumed that the specific aforementioned endpoint was required exactly as shown, hence, why I created an endpoint that displays the guids of the questions
3. I've added endpoints that allows us to either grab one question, or answer a question.
4. I've used InMemoryCache as data storage.
5. Structured the app in a little bit more complex way, where we can avoid vendor locking-in with repository pattern..
6. Used Mediatr and FluentValidation (more complex) for better flow.

##### Areas to improve
1. Better error handling, I put a very basic one.
2. Better Validation, I put a very basic one.
3. More unit tests.
4. If code did not use InMemoryCache, it would get rid of a lot of null worries.