pipeline {
    agent any

    stages {

        stage('Checkout') {
            steps {
                echo 'Checking out source code'
            }
        }

        stage('Restore') {
            steps {
                echo 'Restoring dependencies'
            }
        }

        stage('Build') {
            steps {
                echo 'Building Web API'
            }
        }

        stage('Test') {
            steps {
                echo 'Running unit tests'
            }
        }

        stage('Publish') {
            steps {
                echo 'Publishing Web API'
            }
        }

        stage('Deliver') {
            steps {
                echo 'Delivering application'
            }
        }
    }
}
