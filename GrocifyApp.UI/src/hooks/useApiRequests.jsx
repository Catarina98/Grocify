import { useState } from 'react';

//Consts
import ApiEndpoints from '../consts/ApiEndpoints';

const useApiRequest = () => {
    const [isLoading, setIsLoading] = useState(false);
    const token = localStorage.getItem('token');

    const makeRequest = async (endpoint, method, body, query = {}) => {
        setIsLoading(true);
        let errorMessage = '';

        try {
            const queryString = Object.keys(query)
                .filter(key => query[key] !== null && query[key] !== "" && query[key] !== undefined)
                .map(key => `${encodeURIComponent(key)}=${encodeURIComponent(query[key])}`)
                .join('&');

            const url = queryString ? `${endpoint}${ApiEndpoints.Filtered}?${queryString}` : endpoint;
            
            const bodyJson = body != null ? JSON.stringify(body) : null;

            const response = await fetch(url, {
                method: method,
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`,
                },
                body: bodyJson,
            });

            if (!response.ok) {
                const errorData = await response.json();
                errorMessage = errorData.error;
                throw new Error(errorMessage);
            }

            if (response.status === 204) {
                return null;
            }

            return await response.json();
        } catch (error) {
            console.error('Error occurred:', error.message);
            throw new Error(errorMessage != null ? errorMessage : 'An error occurred.Please try again.');
        } finally {
            setIsLoading(false);
        }
    };

    return { makeRequest, isLoading };
};

export default useApiRequest;
